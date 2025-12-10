using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public float lifetime = 1f;
    public float floatSpeed = 3f;
    public TextMeshPro text;

    private float timer = 0f;

    public void SetValue(float amount)
    {
        text.text = amount.ToString();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // move upward in UI space
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;

        // fade out
        float alpha = 1f - (timer / lifetime);
        var color = text.color;
        color.a = alpha;
        text.color = color;

        if (timer >= lifetime)
            Destroy(gameObject);
    }
}
