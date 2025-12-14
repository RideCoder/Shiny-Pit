using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerStatUpgradeButton : MonoBehaviour
{

    public TMP_Text text;
    public PlayerStats stats;
    

 
    
    public event Action OnClicked;
    public float amountChosen;

    private void Start()
    {
      

    }

    private void UpdateText()
    {
      

    }

    public void SelectedButton()
    {
        OnClicked?.Invoke();
      

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
