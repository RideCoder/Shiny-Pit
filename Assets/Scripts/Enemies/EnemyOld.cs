using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class EnemyOld : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public Rigidbody2D rb;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb != null)
        {
          
            if (player.transform.position.x > rb.position.x)
            {
                rb.AddForceX(1);
            }
            else
            {
               
                    rb.AddForceX(-1);
                
            }
        }

        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        Tilemap tilemap = collision.collider.GetComponent<Tilemap>();
        if (tilemap == null) return;
        if (rb.linearVelocityX < 0.001f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 24f);
        }
        
      
    }
}
