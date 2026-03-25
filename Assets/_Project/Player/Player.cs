using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        PlayerInputHandler.OnJumpPressed += Jump;
    }

    private void OnDisable()
    {
        PlayerInputHandler.OnJumpPressed -= Jump;
    }

    private void Jump()
    {
        rb.linearVelocity = Vector2.up * 5f;
    }
}