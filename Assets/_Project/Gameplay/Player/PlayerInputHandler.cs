using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInputHandler : MonoBehaviour
{
    public static event Action OnJumpPressed;
    public static event Action OnDashPressed;
    
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnJump()
    {
        OnJumpPressed?.Invoke();
    }

    public void OnDash()
    {
        OnDashPressed?.Invoke();
    }
}