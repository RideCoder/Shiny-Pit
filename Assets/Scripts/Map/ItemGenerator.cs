using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class ItemGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TilemapData Tilemapdata;
    public GameObject craftingView;
    private Vector3Int tilePosition;
    public List<GameObject> items;
    public GameObject craftingPowerup;
    public RecipeView recipeReference;
    public void Start()
    {
        foreach (var item in items)
        {
            for (int i = 0; i < 100; ++i)
            {
                GameObject clone = Instantiate(item);
                clone.GetComponent<BaseStatBoost>().Tilemapdata = Tilemapdata;
                int x = Random.Range(0, 500);
                int y = Random.Range(400, 510);
                clone.transform.position = Tilemapdata.tilemap.CellToWorld(new Vector3Int(x, y, 0));

                clone.transform.position += new Vector3(0.5f, 0.5f, -5f);

                GameObject craftingPowerupClone = Instantiate(craftingPowerup);
                craftingPowerupClone.GetComponent<CraftingPowerup>().Tilemapdata = Tilemapdata;
                craftingPowerupClone.GetComponent<CraftingPowerup>().craftingView = craftingView;
                craftingPowerupClone.GetComponent<CraftingPowerup>().recipeReference = recipeReference;
                x = Random.Range(0, 500);
                y = Random.Range(400, 510);
                craftingPowerupClone.transform.position = Tilemapdata.tilemap.CellToWorld(new Vector3Int(x, y, 0));

                craftingPowerupClone.transform.position += new Vector3(0.5f, 0.5f, -5f);


            }

            //  tilePosition = Tilemapdata.tilemap.WorldToCell(transform.position);

            //  Tilemapdata.OnTileBroke += TileInDestroyed;

        }


    }

    
}
