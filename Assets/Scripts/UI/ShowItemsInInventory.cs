using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ShowItemsInInventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Inventory playerInventory;
    public GameObject contentView;
    public GameObject UIElement;

    public GameObject weaponContentView;
    
    void Start()
    {
        playerInventory.OnInventoryChanged += UpdateVisual;
    }

    public void UpdateVisual()
    {
        foreach (Transform child in contentView.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in weaponContentView.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in playerInventory.inventory)
        {
            if (item.Key is not WeaponSO)
            {
                GameObject clone = Instantiate(UIElement);
                clone.transform.SetParent(contentView.transform, false);
                clone.transform.Find("ItemCount").GetComponent<TMP_Text>().text = item.Value.ToString();
                clone.GetComponent<Image>().sprite = item.Key.sprite;
            }
        }

        foreach (var item in playerInventory.inventory)
        {
            if (item.Key is WeaponSO)
            {
                GameObject clone = Instantiate(UIElement);
                clone.transform.SetParent(weaponContentView.transform, false);
                clone.transform.Find("ItemCount").GetComponent<TMP_Text>().text = item.Value.ToString();
                clone.GetComponent<Image>().sprite = item.Key.sprite;
            }
        }
    }
 
 
}
