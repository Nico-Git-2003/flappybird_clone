using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public float jumpForce = 5f;
    public float dashForce = 25f;
    public float moveSpeed = 15f;
    public float fallSpeed = 3;

    [SerializeField]private bool isDashing = false;
    [SerializeField] private float dashTime = 0.5f;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        PlayerInputHandler.OnJumpPressed += Jump;
        PlayerInputHandler.OnDashPressed += StartDash;
        PlayerInputHandler.OnDownPressed += ApplyGravity;
        PlayerInputHandler.OnDownReleased += ResetGravity;
    }

    void OnDisable()
    {
        PlayerInputHandler.OnJumpPressed -= Jump;
        PlayerInputHandler.OnDashPressed -= StartDash;
        PlayerInputHandler.OnDownPressed -= ApplyGravity;
        PlayerInputHandler.OnDownReleased -= ResetGravity;
    }
    
    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    IEnumerator Dash()
    {
        if (!isDashing)
        {
            isDashing = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x * dashForce, rb.linearVelocity.y);
            yield return new WaitForSeconds(dashTime);
            isDashing = false;   
        }
    }

    void StartDash()
    {
        StartCoroutine(Dash());
    }

    void ApplyGravity()
    {
        rb.gravityScale = fallSpeed;
    }

    void ResetGravity()
    {
        rb.gravityScale = 1;
    }

    void FreezePlayer()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Die()
    {
        FreezePlayer();
        GameManager.Instance.CurrentState =  GameManager.GameState.GameOver;
    }
}