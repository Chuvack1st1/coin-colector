
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputMovement
{
    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool sprint;

    [Header("Movement Settings")]
    public bool analogMovement;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;

    private PlayerMovementContol inputs;
    PlayerMovementContol.MovementActions movementActions;

    public void InitWaklingInput()
    {
        inputs = new PlayerMovementContol();
        movementActions = new PlayerMovementContol.MovementActions(inputs);

        movementActions.Move.started += OnMove;
        movementActions.Move.performed += OnMove;
        movementActions.Move.canceled += OnMove;

        movementActions.Look.started += OnLook;
        movementActions.Look.performed += OnLook;
        movementActions.Look.canceled += OnLook;

        movementActions.Sprint.started += OnSprint;
        movementActions.Sprint.performed += OnSprint;
        movementActions.Sprint.canceled += OnSprint;
    }

    public void EnableInput()
    {
        if (inputs != null)
        {
            inputs.Enable();
        }
    }

    public void DisableInput()
    {
        if (inputs != null)
        {
            inputs.Disable();
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jump = context.ReadValueAsButton();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        sprint = context.ReadValueAsButton(); 
    }
}
