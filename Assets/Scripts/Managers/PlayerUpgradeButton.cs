using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerUpgradeButton : MonoBehaviour
{
   
    [Header("References")]
    public Inventory inventory;
    public WeaponInventoryManager weaponInventoryManager;
    public TMP_Text text;

    [Header("Weapon Pool")]
    public List<WeaponSO> weapons;

    [Header("Runtime")]
    public WeaponSO weaponSO;

    public WeaponUpgrade upgradeChosen;
    public event Action OnClicked;
    public float amountChosen;

    private void Start()
    {
        weaponInventoryManager =
            inventory.GetComponent<WeaponInventoryManager>();

        weaponSO = weapons[UnityEngine.Random.Range(0, weapons.Count)];

       
        // If player already owns this weapon, roll a stat upgrade instead
        if (inventory.inventory.ContainsKey(weaponSO))
        {
            upgradeChosen = weaponSO.weapon.GetComponent<PlayerWeapon>().upgrades[UnityEngine.Random.Range(0, weaponSO.weapon.GetComponent<PlayerWeapon>().upgrades.Count)];
            amountChosen = UnityEngine.Random.Range(7, 22);
            UpdateText();
           

        }
        else
        {
            text.text = weaponSO.name;
        }

            
    }

    private void UpdateText()
    {
        text.text = weaponSO.name + " " + upgradeChosen.name + " " + amountChosen + "%";
       
    }

    public void SelectedButton()
    {
        OnClicked?.Invoke();
        if (upgradeChosen != null)
        {
        
            foreach (var weapon in weaponInventoryManager.weapons
                     .Where(w => w != null && w.weaponSO == weaponSO))
            {
                upgradeChosen.Apply(weapon, 1f + (amountChosen/100f));
            }
            
            
        }
        else
        {
            inventory.AddItem(weaponSO, 1);
            
            
        }
        
       // 
    }

  /*  private void ApplyFireRateUpgrade()
    {
        foreach (var weapon in weaponInventoryManager.weapons
                     .Where(w => w != null && w.weaponSO == weaponSO))
        {
            weapon.baseCooldown /= 1.1f;
        }
    }

    private void ApplyDamageUpgrade()
    {
        foreach (var weapon in weaponInventoryManager.weapons
                     .Where(w => w != null && w.weaponSO == weaponSO))
        {
            weapon.baseDamage *= 1.1f;
        }
    }*/
}
