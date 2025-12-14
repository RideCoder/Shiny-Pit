using UnityEngine;

public class DamageNumberManager : MonoBehaviour
{
    public static DamageNumberManager instance;

    [Header("Damage Number Settings")]
    public GameObject damageNumberPrefab; // prefab with text, animation, etc.

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void ShowDamage(Vector3 position, float amount)
    {
        if (instance == null || instance.damageNumberPrefab == null) return;

        GameObject go = Instantiate(instance.damageNumberPrefab, position, Quaternion.identity);
        DamageNumber number = go.GetComponent<DamageNumber>();
        if (number != null)
            number.SetValue(amount);
    }
}