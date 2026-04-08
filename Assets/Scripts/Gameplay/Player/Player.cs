using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float timer = 0;

    [HideInInspector] public float baseJumpForce = 5f;
    [HideInInspector] public float baseMoveSpeed = 15f;
    [HideInInspector] public float baseDashForce = 25f;
    [HideInInspector] public float baseDashCooldown = 1.5f;
    [HideInInspector] public float baseFallSpeed = 3f;
    [HideInInspector] public float baseDashTime = 0.3f;
    
    public float jumpForce;
    public float moveSpeed;
    public float dashForce;
    public float dashCooldown;
    public float fallSpeed;
    public float dashTime;

    public bool canDash = false;
    public bool isDashing = false;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        jumpForce = baseJumpForce;
        moveSpeed = baseMoveSpeed;
        dashForce = baseDashForce;
        dashCooldown = baseDashCooldown;
        fallSpeed = baseFallSpeed;
        dashTime = baseDashTime;
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

    private void Update()
    {
        if(GameManager.Instance.CurrentState != GameManager.GameState.Playing)
            FreezePlayer();
        else rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (GameManager.Instance.canDash)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 )
            {
                canDash = true;
                timer = 0;
            }   
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
            rb.linearVelocity = new Vector2(dashForce, rb.linearVelocity.y);
            yield return new WaitForSeconds(dashTime);
            isDashing = false;
        }
    }

    void StartDash()
    {
        if (canDash)
        {
            canDash = false;
            timer = dashCooldown;
            StartCoroutine(Dash());
        }
    }

    void ApplyGravity()
    {
        if (GameManager.Instance.fastFall)
        {
            rb.gravityScale = fallSpeed;
        }
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
        GameManager.Instance.CurrentState =  GameManager.GameState.GameOver;
    }
}