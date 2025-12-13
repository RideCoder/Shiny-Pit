using UnityEngine;

public class FountainGun : PlayerWeapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public GameObject projectilePrefab;
    public float spreadAngle = 10f; // degrees between center and side shots
   
    public override void Fire()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mouseWorld - firePoint.position;
        direction.z = 0f;
        direction.Normalize();
      
        // Middle shot
       // FireProjectile(direction);

        // Spread shots using rotation

        for (int i = 0; i < 5; i++)
        {
            FireProjectile(RotateVector(new Vector3(0,10,0), Random.Range(-spreadAngle,spreadAngle)));
        }
        
        

        cooldownTimer = baseCooldown;
    }

    private void FireProjectile(Vector3 direction)
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        Projectile projectile = proj.GetComponent<Projectile>();
        projectile.damage = playerStats.damageMultiplier * baseDamage;
        projectile.tilemapData = tilemapData;
        
        projectile.Shoot(direction);
    }

    // Rotate a Vector3 around the Z axis by 'angleDeg' degrees
    private Vector3 RotateVector(Vector3 v, float angleDeg)
    {
        float rad = angleDeg * Mathf.Deg2Rad;
        float sin = Mathf.Sin(rad);
        float cos = Mathf.Cos(rad);

        float newX = (v.x * cos) - (v.y * sin);
        float newY = (v.x * sin) + (v.y * cos);

        return new Vector3(newX, newY, 0f);
    }

 
}
