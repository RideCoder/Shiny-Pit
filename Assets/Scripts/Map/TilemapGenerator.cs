using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SmoothTerrainGenerator : MonoBehaviour
{
    public int width = 300;
    public int maxHeight = 200;

    public float noiseScale = 0.015f;
    public int baseTerrainHeight = 40;
    public int heightMultiplier = 40;
    public int smoothingPasses = 1;

    public DestructibleTile dirtTile;
    public DestructibleTile stoneTile;
    public DestructibleTile oreTile;
    public DestructibleTile bedrockTile;
    public Tilemap tilemap;
    
    private Dictionary<Vector3Int, ItemSO> tileData = new Dictionary<Vector3Int, ItemSO>();
    private int[] terrainHeights;
    public int seed = 0;

    void Start()
    {
        //seed = Random.Range(0, 20000);
        terrainHeights = new int[width];
        GenerateHeights();
        SmoothHeights();

        RenderTerrain();
        
       for (int i = 0; i < 10; i++)
        {
            CreateOre(UnityEngine.Random.Range(0,20000));
        }
        // CreateCaves(UnityEngine.Random.Range(0, 20000));
        for (int x = 0; x < width; x++)
        {
            for (int y = 100; y < maxHeight - 60; y++)
            {
               
                    tilemap.SetTile(new Vector3Int(x, y, 0), bedrockTile);
                


            }
        }


    }
    void CreateCaves(int seed)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 300; y < maxHeight + 4; y++)
            {
                float noise = Mathf.PerlinNoise(((x + (seed * 2000)) * 0.05f), (((y + (seed * 2000)) * 0.05f)));
                if (noise > 0.5)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), null);
                }


            }
        }
    }
    void CreateOre(int seed)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 300; y < maxHeight+4; y++)
            {
                float noise = Mathf.PerlinNoise(((x + (seed * 2000)) * 0.05f), (((y + (seed * 2000)) * 0.05f)));
                 if (noise > 0.75)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), oreTile);
                }


            }
        }
    }
        
            
    
    void GenerateHeights()
    {
        for (int x = 0; x < width; x++)
        {
            float noise = Mathf.PerlinNoise((x * noiseScale)+(seed*2000), 0f);
            int height = baseTerrainHeight + Mathf.RoundToInt(noise * heightMultiplier);
            terrainHeights[x] = height;
        }
    }

    void SmoothHeights()
    {
        for (int pass = 0; pass < smoothingPasses; pass++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                terrainHeights[x] =
                    (terrainHeights[x - 1] +
                     terrainHeights[x] +
                     terrainHeights[x + 1]) / 3;
            }
        }
    }

    void RenderTerrain()
    {
        for (int x = 0; x < width; x++)
        {
            int surfaceY = terrainHeights[x];

            for (int y = 0; y < surfaceY; y++)
            {
                DestructibleTile tileToPlace =  (y < surfaceY - 5) ? stoneTile : dirtTile;
                
                tilemap.SetTile(new Vector3Int(x, y, 0), tileToPlace);
            }
        }
    }

}
