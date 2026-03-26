using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInputHandler : MonoBehaviour
{
    public static event Action OnJumpPressed;
    public static event Action OnDashPressed;
    public static event Action OnDownPressed;
    public static event Action OnDownReleased;
    
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
    
    public void OnDown()
    {
        playerInput.actions["Down"].performed += ctx => OnDownPressed?.Invoke();
        playerInput.actions["Down"].canceled += ctx => OnDownReleased?.Invoke();
    }
    
}