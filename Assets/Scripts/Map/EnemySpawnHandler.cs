using UnityEngine;
using UnityEngine.Tilemaps;

class EnemySpawnHandler : MonoBehaviour
{
    public TilemapData tilemapData;
    public Tilemap tilemap;
    public GameObject player;
    public void Start()
    {
        WaveSystem.OnSpawnEnemy += SpawnEnemy;
    }

    public void SpawnEnemy(Vector3 pos, Enemy enemy)
    {
        Vector3 spawnPosition = pos;
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
            GameObject clone = Instantiate(enemy.gameObject);
            clone.GetComponent<EnemyAI>().Initialize(player, tilemapData);
            //clone.GetComponent<Health>().maxHealth = 3f;// (3f * playerStats.fireRateMultiplier * playerStats.damageMultiplier);


            clone.transform.position = spawnPosition;

            
        }
    }
}