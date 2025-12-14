using System;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    public float moveSpeed = 2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);
    }
    public void Stop()
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }
    public void Start()
    {
       
    }

   

}