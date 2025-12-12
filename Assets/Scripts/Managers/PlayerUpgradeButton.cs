using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUpgradeButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<WeaponSO> weapons;
    public Inventory inventory;
    public WeaponSO weapon;
    public TMP_Text text;

    public event Action OnClicked;

    void Start()
    {
        weapon = weapons[UnityEngine.Random.Range(0,weapons.Count)];
        if (inventory.inventory.ContainsKey(weapon))
        {
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                weapon.baseDamage *= 1.1f;
                text.text = weapon.name + " Damage 10%+";
            }
            else
            {
                weapon.baseCooldown /= 1.1f;
                text.text = weapon.name + " Firerate 10%+";
            }
            
        } 
        else
        {
            text.text = weapon.name;
        }
            
    }




    public void SelectedButton()
    {
        OnClicked?.Invoke();
        if (!inventory.inventory.ContainsKey(weapon))
        {
            inventory.AddItem(weapon, 1);
        }
            
    }
}
