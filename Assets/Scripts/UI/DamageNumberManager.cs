using UnityEngine;

public class DamageNumberManager : MonoBehaviour
{
    public static DamageNumberManager instance;

    [Header("Damage Number Settings")]
    public GameObject damageNumberPrefab; // prefab with text, animation, etc.
    public GameObject damageNumberCritPrefab; // prefab with text, animation, etc.
    public PlayerStats playerStats;
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

    public static void ShowDamageCrit(Vector3 position, float amount)
    {
        if (instance == null || instance.damageNumberCritPrefab == null) return;

        GameObject go = Instantiate(instance.damageNumberCritPrefab, position, Quaternion.identity);
        DamageNumber number = go.GetComponent<DamageNumber>();
        if (number != null)
            number.SetValue(amount, " Crit");
    }
}