using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public float jumpForce = 5f;
    public float dashForce = 25f;
    public float moveSpeed = 15f;

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
    }

    void OnDisable()
    {
        PlayerInputHandler.OnJumpPressed -= Jump;
        PlayerInputHandler.OnDashPressed -= StartDash;
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

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
    }

    public void Die()
    {
        moveSpeed = 0;
        jumpForce = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}