using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour 
{
    private PlayerController playerController;
    public InputAction horizontalMovement;
    public InputAction roll;
    public InputAction jump;

    private void Awake()
    {
        playerController = new PlayerController();

        horizontalMovement = playerController.InGame.HorizontalMovement;
        horizontalMovement.Enable();

        roll = playerController.InGame.Roll;
        roll.Enable();

        jump = playerController.InGame.Jump;
        jump.Enable();
    }

    private void OnDisable()
    {
        horizontalMovement.Disable();
        roll.Disable();
        jump.Disable();

    }
}
