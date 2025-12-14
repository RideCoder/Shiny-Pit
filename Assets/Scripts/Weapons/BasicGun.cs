using UnityEngine;

public class BasicGun : PlayerWeapon
{
    public GameObject projectilePrefab;
    public LayerMask tileLayerMask;   // Layer mask for tilemap collider

    public int rayCount = 64;         // Number of rays around the circle
    public float rayDistance = 15f;   // How far each ray checks

    public override void Fire()
    {
        Vector3 origin = firePoint.position;
        Vector2 bestPoint = Vector2.zero;
        float bestDistance = float.MaxValue;
        bool foundHit = false;
        if (playerStats.gameObject.GetComponent<PlayerController2D>().IsGrounded())
        {
   
            // Sweep 360°
            for (int i = 0; i < rayCount; i++)
            {
                float angle = (i * (180f / rayCount));
             
                Vector2 dir = DirFromAngle(angle);

                RaycastHit2D hit = Physics2D.Raycast(origin + new Vector3(0,-.5f,0), dir, rayDistance, tileLayerMask);
                if (hit.collider != null)
                {
                    float dist = hit.distance;
                    if (dist < bestDistance)
                    {
                        bestDistance = dist;
                        bestPoint = hit.point;
                        foundHit = true;
                    }
                }
            }

        }
        else
        {
      
            // Sweep 360°
            for (int i = 0; i < rayCount; i++)
            {
                float angle = i * (360f / rayCount);
                Vector2 dir = DirFromAngle(angle);

                RaycastHit2D hit = Physics2D.Raycast(origin, dir, rayDistance, tileLayerMask);
                if (hit.collider != null)
                {
                    float dist = hit.distance;
                    if (dist < bestDistance)
                    {
                        bestDistance = dist;
                        bestPoint = hit.point;
                        foundHit = true;
                    }
                }
            }

        }

        if (!foundHit)
            return; // No tile in range

        // Fire toward closest tile hit
        Vector3 direction = (bestPoint - (Vector2)origin).normalized;
        FireProjectile(direction);
    }

    private void FireProjectile(Vector3 direction)
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        Projectile projectile = proj.GetComponent<Projectile>();
        projectile.damage = playerStats.GetStat(StatType.DamageMultiplier) * baseDamage;
        projectile.critChance = playerStats.GetStat(StatType.CritChance);
        projectile.critDamage = playerStats.GetStat(StatType.CritMultiplier);
        projectile.tilemapData = tilemapData;
        projectile.Shoot(direction);

        cooldownTimer = baseCooldown;
    }

    private Vector2 DirFromAngle(float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
    }
}
