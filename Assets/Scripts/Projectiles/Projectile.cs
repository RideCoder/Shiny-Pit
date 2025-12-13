using UnityEngine;
using UnityEngine.Tilemaps;

public class Projectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TilemapData tilemapData;
    public float speed = 20f;
    public float damage;
    private Vector3 direction;
    private Rigidbody2D rb;
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
       
    }

    public void Shoot(Vector3 dir)
    {
        direction = dir.normalized;
        rb.linearVelocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageble damageble = collision.collider.GetComponent<IDamageble>();
        
        if (damageble != null)
        {
            
            damageble.TakeDamage(damage);
            Destroy(gameObject);
        }
        Tilemap tilemap = collision.collider.GetComponent<Tilemap>();
        if (tilemap == null) return;

        // Use the first contact that has a valid point
        ContactPoint2D contact = collision.GetContact(0);
        Vector2 hitWorld2D = contact.point;
        Vector2 normal = contact.normal;

        // Move the sample point *into* the tile by a small epsilon.
        // Use a fraction of the tile cell size; this scales properly for non-1-sized cells.
        Vector3 cellSize = tilemap.cellSize;
        float epsilon = Mathf.Min(cellSize.x, cellSize.y) * 0.25f; // 10% of a cell -- tune smaller if needed

        Vector2 samplePoint = hitWorld2D - normal * epsilon;
        Vector3Int tilePos = tilemap.WorldToCell((Vector3)samplePoint);
        
        // Optional safety: if sampled tile is empty, try a smaller epsilon or try other contact points
        if (tilemap.GetTile(tilePos) == null)
        {
            // Try smaller epsilon
            float smallEps = Mathf.Min(cellSize.x, cellSize.y) * 0.2f;
            samplePoint = hitWorld2D - normal * smallEps;
            tilePos = tilemap.WorldToCell((Vector3)samplePoint);
        }

        // Finally apply damage if there's a destructible tile there
        Debug.Log(damage);
        tilemapData.DamageTile(tilePos, damage);
        DamageNumberManager.ShowDamage(transform.position, damage);
        Destroy(gameObject);
    }



}
