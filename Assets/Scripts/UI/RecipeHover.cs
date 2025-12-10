using UnityEngine;
using UnityEngine.EventSystems;


public class RecipeHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject recipeView;
    public CraftingRecipeSO recipe;
    public GameObject recipeItem;
    public void OnPointerEnter(PointerEventData eventData)
    {

        recipeView.SetActive(true);
        //foreach (var recipe in )
        // Perform actions when mouse enters (e.g., change color, show tooltip)
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        recipeView.SetActive(false);
        // Perform actions when mouse exits (e.g., revert color, hide tooltip)
    }
}
