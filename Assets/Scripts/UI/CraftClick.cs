using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;
public class CraftClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CraftingRecipeSO CraftingRecipeSO;
    public RecipeView recipe;
    public GameObject recipeView;
    public GameObject itemView;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

  
    public void OnPointerClick(PointerEventData eventData)
    {
        recipe.Craft(CraftingRecipeSO);
        // Add your desired actions here
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        recipeView.SetActive(true);
        foreach (var ingreident in CraftingRecipeSO.ingredients)
        {
            GameObject clone = Instantiate(itemView);
            clone.transform.parent = recipeView.transform;
            clone.GetComponent<Image>().sprite = ingreident.item.sprite;
            clone.transform.Find("ItemCount").GetComponent<TMP_Text>().text = ingreident.quantity.ToString();
            //   clone.GetComponent<>

        }
        // Perform actions when mouse enters (e.g., change color, show tooltip)
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        recipeView.SetActive(false);
        foreach (Transform child in recipeView.transform)
        {
            Destroy(child.gameObject);
        }
        // Perform actions when mouse exits (e.g., revert color, hide tooltip)
    }
}
