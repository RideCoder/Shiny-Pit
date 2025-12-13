using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Injected Dependencies")]
    public Transform firePoint;
    public TilemapData tilemapData;
    public WeaponSO weaponSO;
    public PlayerStats playerStats;
    public float baseCooldown;
    public float baseDamage;

    protected float cooldownTimer;
    private void Start()
    {
       
        cooldownTimer = GetEffectiveCooldown();
    }
    public void Tick(float dt)
    {
        cooldownTimer -= dt;
        if (cooldownTimer <= 0f)
        {
            Fire();
            cooldownTimer = GetEffectiveCooldown();
        }
    }

    protected virtual float GetEffectiveCooldown()
    {
        float baseCooldownTemp = baseCooldown;

        return baseCooldownTemp;
    }
    protected float GetEffectiveDamage()
    {
        return baseDamage * playerStats.damageMultiplier;
    }

    // Base Fire method – override for custom weapon behavior
    public virtual void Fire()
    {
        Debug.Log($"{weaponSO.name} fired (override me)");
    }

    // If weapons need initialization logic, override this safely
    protected virtual void Awake()
    {
      //  cooldownTimer = GetEffectiveCooldown();
    }
}
