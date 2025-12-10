using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class ItemGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TilemapData Tilemapdata;
    private Vector3Int tilePosition;
    public List<GameObject> Items;

    public void Start()
    {
        foreach (var item in Items)
        {
            for (int i = 0; i < 1000; ++i)
            {
                GameObject clone = Instantiate(item);
                clone.GetComponent<BaseItem>().Tilemapdata = Tilemapdata;
                int x = Random.Range(0, 500);
                int y = Random.Range(400, 509);
                clone.transform.position = Tilemapdata.tilemap.CellToWorld(new Vector3Int(x, y, 0));

                clone.transform.position += new Vector3(0.5f, 0.5f, -5f);
            }

            //  tilePosition = Tilemapdata.tilemap.WorldToCell(transform.position);

            //  Tilemapdata.OnTileBroke += TileInDestroyed;

        }
    }

    
}
