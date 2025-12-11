using UnityEngine;

public class BulletThorns : BaseItem
{
    private WorldState worldState;
    public GameObject projectilePrefab;
 
    public override void AddToPlayer(WorldState wS)
    {
        worldState = wS;
        wS.playerController.OnPlayerMoved += PlayerMoved;
    }

    public void PlayerMoved()
    {
        if (Random.Range(0f, 1f) <= 0.1f)
        {
            GameObject proj = Instantiate(projectilePrefab, worldState.playerController.gameObject.transform.position + new Vector3(0, .5f, 0), Quaternion.identity);

            Projectile projectile = proj.GetComponent<Projectile>();
            projectile.damage = 5;
            projectile.tilemapData = worldState.tilemapData;
            projectile.Shoot(new Vector3(Random.Range(-4f,4f), 10, Random.Range(-4f, 4f)));
        }
    }
}
