using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockExplodeItem : BaseItem
{
    private WorldState worldState;
    public GameObject projectilePrefab;

    public override void AddToPlayer(WorldState wS)
    {
        worldState = wS;
        worldState.tilemapData.OnTileBroke += ShootProjectiles;
    }

    public void ShootProjectiles(Tile tile)
    {
        if (Random.Range(0, 10) == 0)
        {
            for (int i = 0; i < Random.Range(2, 4); i++)
            {
                GameObject proj = Instantiate(projectilePrefab, worldState.playerController.gameObject.transform.position + new Vector3(0, 2f, 0), Quaternion.identity);

                Projectile projectile = proj.GetComponent<Projectile>();
                projectile.damage = 2;
                projectile.tilemapData = worldState.tilemapData;
                projectile.Shoot(new Vector3(Random.Range(-15f, 15f), 20, Random.Range(-15f, 15f)));
            }
        }
    }
}
