using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Destructible Tile", menuName = "Tiles/DestructibleTile")]
public class DestructibleTile : Tile
{
    public float maxHealth = 3;
    public ItemSO dropItem;



}
