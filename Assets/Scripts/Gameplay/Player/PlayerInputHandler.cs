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
    
    private void OnEnable()
    {
        playerInput.actions["Down"].performed += OnDownPerformed;
        playerInput.actions["Down"].canceled += OnDownCanceled;
    }

    private void OnDisable()
    {
        playerInput.actions["Down"].performed -= OnDownPerformed;
        playerInput.actions["Down"].canceled -= OnDownCanceled;
    }

    
    private void OnDownPerformed(InputAction.CallbackContext ctx)
    {
        OnDownPressed?.Invoke();
    }

    private void OnDownCanceled(InputAction.CallbackContext ctx)
    {
        OnDownReleased?.Invoke();
    }
    
}