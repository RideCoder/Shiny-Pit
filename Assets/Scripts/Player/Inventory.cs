using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public Dictionary<ItemSO,int> inventory = new Dictionary<ItemSO,int>();

    public event Action OnInventoryChanged;
    public event Action<ItemSO> OnItemAddedToInventory;
    public ItemSO startItem;

    void Start()
    {
        AddItem(startItem, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(ItemSO item, int amount)
    {
        if (!inventory.ContainsKey(item))
        {
            inventory.Add(item, amount);
        }
        else
        {
            inventory[item] += amount;
        }

        OnInventoryChanged?.Invoke();
        OnItemAddedToInventory?.Invoke(item);
    }

    public void RemoveItem(ItemSO item, int amount)
    {
        inventory[item] -= amount;
        if (inventory[item] <= 0)
        {
            inventory.Remove(item);
        }
        OnInventoryChanged?.Invoke();
    }
}
