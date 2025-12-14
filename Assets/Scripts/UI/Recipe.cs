using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
public class Recipe : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Inventory playerInventory;
    public GameObject contentView;
    public GameObject UIElement;
    public GameObject recipeView;
    public CraftingRecipeSO[] craftingRecipes;
    public GameObject craftingView;

    
    void Start()
    {
        //playerInventory.OnInventoryChanged += UpdateVisual;
        foreach (Transform child in contentView.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var recipe in craftingRecipes)
        {
            GameObject clone = Instantiate(UIElement);
            clone.transform.SetParent(contentView.transform, false);
            //  clone.transform.Find("ItemCount").GetComponent<TMP_Text>().text = item.Value.ToString();
            clone.GetComponent<Image>().sprite = recipe.resultItem.sprite;
        }



    }

    public void UpdateVisual()
    {
        foreach (Transform child in contentView.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in recipeView.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (var recipe in craftingRecipes)
        {
            GameObject clone = Instantiate(UIElement);
            clone.transform.SetParent(contentView.transform, false);
            //  clone.transform.Find("ItemCount").GetComponent<TMP_Text>().text = item.Value.ToString();
            clone.GetComponent<Image>().sprite = recipe.resultItem.sprite;
            clone.GetComponent<CraftClick>().CraftingRecipeSO = recipe;
            clone.GetComponent<CraftClick>().recipe = this;
            clone.GetComponent<CraftClick>().recipeView = recipeView;
        



        }

    }

    public void Craft(CraftingRecipeSO craftingRecipeSO)
    {
        var canCraft = true;

        foreach (var ingreident in craftingRecipeSO.ingredients)
        {
            Debug.Log(ingreident.item + ": " + ingreident.quantity);
            if (playerInventory.inventory.ContainsKey(ingreident.item))
            {
                if (playerInventory.inventory[ingreident.item] < ingreident.quantity)
                {
                    canCraft = false;
                }
            }
            else
            {
                canCraft = false;
            }
            

        }

        if (canCraft)
        {
            foreach (var ingreident in craftingRecipeSO.ingredients)
            {
                playerInventory.RemoveItem(ingreident.item,ingreident.quantity);
            }
            playerInventory.AddItem(craftingRecipeSO.resultItem,1);
            craftingView.SetActive(false);
            recipeView.SetActive(false);

        }


    }
 


}
