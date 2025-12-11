using UnityEngine;

public class EnemyExplodeItem : BaseItem
{
    private WorldState worldState;
    public GameObject projectilePrefab;

    public override void AddToPlayer(WorldState wS)
    {
        worldState = wS;
        Enemy.OnEnemyDeath += ShootProjectiles;
    }

    public void ShootProjectiles(Vector3 pos)
    {
        for (int i = 0; i < Random.Range(5,8); i++) { 
            GameObject proj = Instantiate(projectilePrefab, pos + new Vector3(0, .5f, 0), Quaternion.identity);

            Projectile projectile = proj.GetComponent<Projectile>();
            projectile.damage = 2;
            projectile.tilemapData = worldState.tilemapData;
            projectile.Shoot(new Vector3(Random.Range(-5f, 5f), 10, Random.Range(-5f, 5f)));
        }
    }
}
