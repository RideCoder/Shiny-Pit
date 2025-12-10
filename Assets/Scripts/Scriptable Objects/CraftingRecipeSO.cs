using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct Ingredient
{
    public ItemSO item;
    public int quantity;
}


[CreateAssetMenu(fileName = "CraftingRecipe", menuName = "Scriptable Objects/CraftingRecipe")]
public class CraftingRecipeSO : ScriptableObject
{
    
    public int craftingRecipeID;
    public List<Ingredient> ingredients;
    public ItemSO resultItem;
}
