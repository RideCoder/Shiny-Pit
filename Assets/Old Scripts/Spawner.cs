using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

[SerializeField]
struct Spawn
{

}
public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public TilemapData tilemapData;
    public Tilemap tilemap;
    public PlayerStats playerStats;
    public float spawnTime = 5f;
    private void Start()
    {
     
        
    }

    private void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            Vector3 spawnPosition = player.transform.position;
            if (Random.Range(0, 2) == 0)
            {
                spawnPosition += new Vector3(10, 0, 0);
            }
            else
            {
                spawnPosition += new Vector3(-10, 0, 0);
            }

            Vector3Int tilePos = tilemap.WorldToCell((Vector3)spawnPosition);

            // Optional safety: if sampled tile is empty, try a smaller epsilon or try other contact points
            if (tilemap.GetTile(tilePos) == null)
            {
                GameObject clone = Instantiate(enemy);
                clone.GetComponent<EnemyAI>().Initialize(player, tilemapData);
               // clone.GetComponent<Health>().maxHealth = (3f * playerStats.fireRateMultiplier * playerStats.damageMultiplier);


                clone.transform.position = spawnPosition;

                spawnTime = 5f;
            }
        }
    }
}

