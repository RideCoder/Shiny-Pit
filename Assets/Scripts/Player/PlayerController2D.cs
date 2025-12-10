using System;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 14f;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
    public PlayerStats playerStats;
    private Rigidbody2D rb;
    private Collider2D col;
    public float moveInput;
    private bool jumpPressed;
    private float modifiedMoveSpeed;

    public event Action OnPlayerMoved;

    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

   
    private void Update()
    {
        modifiedMoveSpeed = moveSpeed * playerStats.movementMultipler;
        // Get input
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;
       
    }

    private void FixedUpdate()
    {

        if (moveInput != 0)
        {
            OnPlayerMoved?.Invoke();
        }
        // Horizontal movement
        rb.linearVelocity = new Vector2(moveInput * modifiedMoveSpeed, rb.linearVelocity.y);

        // Jump
        if (jumpPressed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        jumpPressed = false;
    }

    private bool IsGrounded()
    {
        Vector2 boxCenter = col.bounds.center;
        Vector2 boxSize = new Vector2(col.bounds.size.x, col.bounds.size.y);
        float angle = 0f;

        RaycastHit2D hit = Physics2D.BoxCast(
            boxCenter,
            boxSize,
            angle,
            Vector2.down,
            groundCheckDistance,
            groundLayer
        );

        return hit.collider != null;
    }
}
