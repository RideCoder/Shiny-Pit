using UnityEngine;
using UnityEngine.Tilemaps;

public class LaserProjectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TilemapData tilemapData;
    public float speed = 20f;
    public float damage;
    public float critChance = 0f;
    public float critDamage = 2f;
    public Vector3 direction;
    public Rigidbody2D rb;
    public int bounceCount = 0;
    public int maxBounces = 5;
    public void Start()
    {
        Destroy(gameObject, 10f);
    }

    public void Awake()
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
        if (rb.linearVelocity.sqrMagnitude > 0.01f)
        {
            Vector2 v = rb.linearVelocity;
            float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // === Enemy hit ===
        IDamageble damageble = collision.collider.GetComponent<IDamageble>();
        bool crit = Random.value <= critChance;

        if (damageble != null)
        {
            float finalDamage = crit ? damage * critDamage : damage;
            damageble.TakeDamage(finalDamage);
            Destroy(gameObject);
            return;
        }

        // === Tilemap hit ===
        Tilemap tilemap = collision.collider.GetComponent<Tilemap>();
        if (tilemap == null) return;

        ContactPoint2D contact = collision.GetContact(0);
        Vector2 hitPoint = contact.point;
        Vector2 normal = contact.normal;

        // Tile damage sampling
        Vector3 cellSize = tilemap.cellSize;
        float epsilon = Mathf.Min(cellSize.x, cellSize.y) * 0.2f;
        Vector2 samplePoint = hitPoint - normal * epsilon;
        Vector3Int tilePos = tilemap.WorldToCell(samplePoint);

        if (tilemap.GetTile(tilePos) != null)
        {
            float finalDamage = crit ? damage * critDamage : damage;
            tilemapData.DamageTile(tilePos, finalDamage);

            if (crit)
                DamageNumberManager.ShowDamageCrit(transform.position, finalDamage);
            else
                DamageNumberManager.ShowDamage(transform.position, finalDamage);
        }

        // === Bounce logic ===
        if (bounceCount >= maxBounces)
        {
            Destroy(gameObject);
            return;
        }

        bounceCount++;

        Vector2 incoming = rb.linearVelocity.normalized;
        Vector2 reflected = Vector2.Reflect(incoming, normal);

        rb.linearVelocity = reflected * speed;
    }




}
