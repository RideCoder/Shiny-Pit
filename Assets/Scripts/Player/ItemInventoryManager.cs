using UnityEngine;


public class ItemInventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public WorldState worldState;
    public void Start()
    {
        inventory.OnItemAddedToInventory += ItemAdded;
    }
    public void ItemAdded(ItemSO item)
    {
      
            if (item is SpecialItemSO specialItem)
            {
                specialItem.specialItem.GetComponent<BaseItem>().AddToPlayer(worldState);
            }
        }
}