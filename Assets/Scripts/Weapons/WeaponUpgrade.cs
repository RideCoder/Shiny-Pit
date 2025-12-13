using UnityEngine;

public abstract  class WeaponUpgrade : ScriptableObject
{
    public string name;
    public abstract void Apply(PlayerWeapon weapon, float amount);
}


[CreateAssetMenu(menuName = "Weapons/Upgrades/Damage")]
public class DamageUpgrade : WeaponUpgrade
{
    
    
    public override void Apply(PlayerWeapon weapon, float amount)
    {
        weapon.baseDamage *= amount;
    }
}


[CreateAssetMenu(menuName = "Weapons/Upgrades/Firerate")]
public class FirerateUpgrade : WeaponUpgrade
{
   
    public override void Apply(PlayerWeapon weapon, float amount)
    {
        weapon.baseCooldown /= amount;
    }
}
