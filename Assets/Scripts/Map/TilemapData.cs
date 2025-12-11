using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapData : MonoBehaviour
{
    [Header("References")]
    public Tilemap tilemap;
    public Inventory inventory;
   
    // Prefab used for the white flash overlay
    [Header("Flash Settings")]
    public GameObject flashOverlayPrefab;
    public float flashDuration = 0.08f;

    public event Action<Vector3Int> OnTileBroke;

    // Stores health for each tile position
    private Dictionary<Vector3Int, float> tileHealth = new Dictionary<Vector3Int, float>();

    // ----------------------------------------------------------------------
    // Damages a tile at a given position
    // ----------------------------------------------------------------------
    public void DamageTile(Vector3Int position, float damage)
    {
        DestructibleTile tile = tilemap.GetTile<DestructibleTile>(position);
        if (tile == null) return;

        // Trigger flash overlay
        if (flashOverlayPrefab != null)
            StartCoroutine(FlashTileOverlay(position));

        // Initialize health if needed
        if (!tileHealth.ContainsKey(position))
            tileHealth[position] = tile.maxHealth;

        // Apply damage
        tileHealth[position] -= damage;

        // Destroy tile if health is zero
        if (tileHealth[position] <= 0)
        {
            inventory.AddItem(tile.dropItem, 1);
            tilemap.SetTile(position, null);


            OnTileBroke?.Invoke(position);
            tileHealth.Remove(position);
        }
    }

    // ----------------------------------------------------------------------
    // Creates a white overlay on the tile to simulate a flash
    // ----------------------------------------------------------------------
    private IEnumerator FlashTileOverlay(Vector3Int position)
    {
        if (!tilemap.HasTile(position)) yield break;

        // Get world position at the center of the tile
        Vector3 worldPos = tilemap.GetCellCenterWorld(position);

        // Instantiate overlay prefab as a child of the tilemap
        GameObject overlay = Instantiate(flashOverlayPrefab, worldPos + new Vector3(0,0,-5), Quaternion.identity, tilemap.transform);
        overlay.transform.localScale = Vector3.one; // adjust if needed

        // Optional: fade out for smooth flash
        SpriteRenderer sr = overlay.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            float timer = 0f;
            while (timer < flashDuration)
            {
                //sr.color = Color.Lerp(Color.white, Color.clear, timer / flashDuration);
                timer += Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            // Wait if no SpriteRenderer
            yield return new WaitForSeconds(flashDuration);
        }

        // Destroy overlay after flash
        Destroy(overlay);
    }
}
