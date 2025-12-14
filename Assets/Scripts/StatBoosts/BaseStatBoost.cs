using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class BaseStatBoost : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TilemapData Tilemapdata;
    private Vector3Int tilePosition;

    public void Start()
    {
        if (Tilemapdata.tilemap.WorldToCell(transform.position) != null)
        {
            tilePosition = Tilemapdata.tilemap.WorldToCell(transform.position);
//
            Tilemapdata.OnTileBroke += TileInDestroyed;
        }
        
    }

    public void TileInDestroyed(Tile tile)
    {
        if (tilePosition == tile.transform.GetPosition())
        {
            gameObject.AddComponent<Rigidbody2D>();
        }
       
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Default Player Item Behavior");
        if (collision.collider.TryGetComponent<PlayerStats>(out var playerStats))
        {
            // Now you have weaponsManager as an "out parameter"
            // Use it directly here
            playerStats.RaisePlayerTouchStatBoost();
            Debug.Log("Default Player Item Behavior Activated!");
            Destroy(gameObject);
        }
    }
}
