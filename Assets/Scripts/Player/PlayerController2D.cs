using System;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 6f;
   
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
    public PlayerStats playerStats;
    private Rigidbody2D rb;
    private Collider2D col;
    public float moveInput;
    private bool jumpPressed;
    private float modifiedMoveSpeed;
    public float groundAcceleration = 690f;
    public float airAcceleration = 20f;
    public float groundDeceleration = 80f;
    public float airDeceleration = 20f;
    public event Action OnPlayerMoved;

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

   
    private void Update()
    {
        modifiedMoveSpeed = moveSpeed * playerStats.GetStat(StatType.MovementMultiplier);
       
        // Get input
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Jump"))
            jumpPressed = true;
       
    }

    private void FixedUpdate()
    {
        bool grounded = IsGrounded();

        float accel = grounded ? groundAcceleration : airAcceleration;
        float decel = grounded ? groundDeceleration : airDeceleration;

        float targetSpeed = moveInput * modifiedMoveSpeed;

        float speedDiff = targetSpeed - rb.linearVelocity.x;

        float rate = Mathf.Abs(targetSpeed) > 0.01f ? accel : decel;

        float movement = Mathf.Clamp(speedDiff, -rate * Time.fixedDeltaTime, rate * Time.fixedDeltaTime);

        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x + movement,
            rb.linearVelocity.y
        );

        if (jumpPressed && grounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, playerStats.GetStat(StatType.JumpHeight));
        }

        if (Mathf.Abs(rb.linearVelocity.x) > 0.1f)
            OnPlayerMoved?.Invoke();

        jumpPressed = false;
    }

    public bool IsGrounded()
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
