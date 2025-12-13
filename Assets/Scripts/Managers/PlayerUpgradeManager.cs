using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject button;
    public Inventory inventory;
    public PlayerStats playerStats;
    public GameObject container;
    public List<GameObject> UpgradeButtons;
    void Start()
    {
        playerStats.OnPlayerLevelUp += PlayerLeveledUp;
    
       
    }

    public void ButtonClicked()
    {
        foreach (GameObject button in UpgradeButtons)
        {
            button.GetComponent<PlayerUpgradeButton>().OnClicked -= ButtonClicked;
            Destroy(button.gameObject);
        }
        UpgradeButtons.Clear();

        container.SetActive(false);
    }

    public void PlayerLeveledUp()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject clone = Instantiate(button);
            clone.GetComponent<PlayerUpgradeButton>().inventory = inventory;
            clone.GetComponent<PlayerUpgradeButton>().OnClicked += ButtonClicked;
            clone.transform.parent = container.transform;
            UpgradeButtons.Add(clone);
        }
        container.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
