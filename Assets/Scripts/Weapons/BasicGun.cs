using UnityEngine;

public class BasicGun : PlayerWeapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    public GameObject projectilePrefab;
    public override void Fire()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mouseWorld - firePoint.position;
        direction.z = 0;

        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        Projectile projectile = proj.GetComponent<Projectile>();
        projectile.damage = playerStats.damageMultiplier * weaponSO.baseDamage;
        projectile.tilemapData = tilemapData;
        projectile.Shoot(direction);
        cooldownTimer = weaponSO.baseCooldown;
    }

    

}
