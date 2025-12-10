using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponInventoryManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public List<PlayerWeapon> weapons = new List<PlayerWeapon>();
    public TilemapData tilemapData;
    public Transform firePoint;
    public Inventory inventory;
    public PlayerStats stats;




    public void Start()
    {
        InventoryUpdated();
        inventory.OnInventoryChanged += InventoryUpdated;


      

    }



    public void InventoryUpdated()
    {
        // Dictionary to track counts of weapons in the inventory
        Dictionary<WeaponSO, int> desiredWeaponCounts = new Dictionary<WeaponSO, int>();

        foreach (var item in inventory.inventory)
        {
            if (item.Key is WeaponSO weaponSO)
            {
                
                desiredWeaponCounts[weaponSO] = item.Value;
            }
        }

        // Remove extra weapons
        for (int i = weapons.Count - 1; i >= 0; i--)
        {
            PlayerWeapon weapon = weapons[i];
            WeaponSO weaponSO = weapon.weaponSO; // assuming you have a reference in PlayerWeapon
            if (!desiredWeaponCounts.ContainsKey(weaponSO))
            {
                Destroy(weapon.gameObject);
                weapons.RemoveAt(i);
            }
            else if (desiredWeaponCounts[weaponSO] > 0)
            {
                desiredWeaponCounts[weaponSO]--;
            }
            else
            {
                Destroy(weapon.gameObject);
                weapons.RemoveAt(i);
            }
        }

        // Add missing weapons
        foreach (var kvp in desiredWeaponCounts)
        {
            WeaponSO weaponSO = kvp.Key;
            int countToAdd = kvp.Value;
            for (int i = 0; i < countToAdd; i++)
            {
                GameObject prefab = weaponSO.weapon;
                PlayerWeapon clone = Instantiate(prefab, transform).GetComponent<PlayerWeapon>();
                clone.tilemapData = tilemapData;
                clone.firePoint = firePoint;
                clone.playerStats = stats;
                clone.weaponSO = weaponSO; // store reference for tracking
                weapons.Add(clone);
            }
        }

        // Update existing weapons' references
        foreach (var weapon in weapons)
        {
            weapon.playerStats = stats;
            weapon.tilemapData = tilemapData;
            weapon.firePoint = firePoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetMouseButton(0))
      //  {
           foreach (PlayerWeapon weapon in weapons)
            {

                
                weapon.Tick(Time.deltaTime*stats.fireRateMultiplier);
           
            }
           
     //   }

        /*
        foreach (var weapon in weapons)
        {
            if (weapon.reloadTime <= 0)
            {
                weapon.Fire();
            }
        }*/
    }
}
