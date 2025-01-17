using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour 
{
    private PlayerController playerController;
    public InputAction horizontalMovement;

    private void Awake()
    {
        playerController = new PlayerController();
        horizontalMovement = playerController.InGame.HorizontalMovement;
        horizontalMovement.Enable();
    }

    private void OnDisable()
    {
        horizontalMovement.Disable();
    }
}
