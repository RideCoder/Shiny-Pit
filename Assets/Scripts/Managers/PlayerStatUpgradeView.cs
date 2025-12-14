using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerStatUpgradeView : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject button;
  
    public PlayerStats playerStats;
    public GameObject container;
    public List<GameObject> UpgradeButtons;
    void Start()
    {

        playerStats.OnPlayerTouchStatBoost += PlayerPickedUpStatUpgrade;

    }

    public void ButtonClicked()
    {
        foreach (GameObject button in UpgradeButtons)
        {
            button.GetComponent<PlayerStatUpgradeButton>().stats = playerStats;
            button.GetComponent<PlayerStatUpgradeButton>().OnClicked -= ButtonClicked;
            Destroy(button.gameObject);
        }
        UpgradeButtons.Clear();

        container.SetActive(false);
    }

    public void PlayerPickedUpStatUpgrade()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject clone = Instantiate(button);
            clone.GetComponent<PlayerStatUpgradeButton>().stats = playerStats;
            clone.GetComponent<PlayerStatUpgradeButton>().OnClicked += ButtonClicked;
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
