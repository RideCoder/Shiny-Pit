using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class DamageItem : BaseItem
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerStats>(out var playerStats))
        {
            // Now you have weaponsManager as an "out parameter"
            // Use it directly here
            playerStats.damageMultiplier *= 1.1f;
            Destroy(gameObject);
        }
    }
}
