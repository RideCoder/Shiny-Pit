using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerUpgradeButton : MonoBehaviour
{
    public enum UpgradeType
    {
        WeaponAdd,
        FireRate,
        Damage
    }

    [Header("References")]
    public Inventory inventory;
    public WeaponInventoryManager weaponInventoryManager;
    public TMP_Text text;

    [Header("Weapon Pool")]
    public List<WeaponSO> weapons;

    [Header("Runtime")]
    public WeaponSO weaponSO;
    public UpgradeType upgradeType;

    public event Action OnClicked;

    private void Start()
    {
        weaponInventoryManager =
            inventory.GetComponent<WeaponInventoryManager>();

        weaponSO = weapons[UnityEngine.Random.Range(0, weapons.Count)];

        // Default upgrade
        upgradeType = UpgradeType.WeaponAdd;

        // If player already owns this weapon, roll a stat upgrade instead
        if (inventory.inventory.ContainsKey(weaponSO))
        {
            int count = Enum.GetValues(typeof(UpgradeType)).Length;
            upgradeType = (UpgradeType)UnityEngine.Random.Range(1, count);
        }

        UpdateText();
    }

    private void UpdateText()
    {
        switch (upgradeType)
        {
            case UpgradeType.WeaponAdd:
                text.text = weaponSO.name;
                break;

            case UpgradeType.FireRate:
                text.text = $"{weaponSO.name} Fire Rate +10%";
                break;

            case UpgradeType.Damage:
                text.text = $"{weaponSO.name} Damage +10%";
                break;
        }
    }

    public void SelectedButton()
    {
        OnClicked?.Invoke();

        switch (upgradeType)
        {
            case UpgradeType.WeaponAdd:
                inventory.AddItem(weaponSO, 1);
                break;

            case UpgradeType.FireRate:
                ApplyFireRateUpgrade();
                break;

            case UpgradeType.Damage:
                ApplyDamageUpgrade();
                break;
        }
    }

    private void ApplyFireRateUpgrade()
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
    }
}
