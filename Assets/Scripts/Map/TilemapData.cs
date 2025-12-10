using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapData : MonoBehaviour
{
    public Tilemap tilemap;
    public Inventory inventory;
    public event Action<Vector3Int> OnTileBroke;
    // Stores health for each tile position
    private Dictionary<Vector3Int, float> tileHealth = new Dictionary<Vector3Int, float>();
   
    public void DamageTile(Vector3Int position, float damage)
    {
        DestructibleTile tile = tilemap.GetTile<DestructibleTile>(position);
        if (tile == null) return;
     
        // Initialize health if not already
        if (!tileHealth.ContainsKey(position))
        {

            tileHealth[position] = tile.maxHealth;
        }
        
        // Reduce health
        tileHealth[position] -= damage;
     
        if (tileHealth[position] <= 0)
        {


            inventory.AddItem(tilemap.GetTile<DestructibleTile>(position).dropItem, 1);
            tilemap.SetTile(position, null); // Destroy the tile
            OnTileBroke?.Invoke(position);
            tileHealth.Remove(position);
        }
    }
}
