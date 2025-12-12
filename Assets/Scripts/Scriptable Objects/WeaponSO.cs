using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class WeaponSO : ItemSO
{
    public float baseCooldown;
    public float baseDamage;
    
    public GameObject weapon;
}
