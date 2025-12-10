using UnityEngine;


public class ItemInventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public PlayerState playerState;
    public void Start()
    {
        inventory.OnItemAddedToInventory += ItemAdded;
    }
    public void ItemAdded(ItemSO item)
    {
        Debug.Log("ITEM ADDED");
            if (item is SpecialItemSO specialItem)
            {
                specialItem.specialItem.GetComponent<BaseItem>().AddToPlayer(playerState);
            }
        }
}