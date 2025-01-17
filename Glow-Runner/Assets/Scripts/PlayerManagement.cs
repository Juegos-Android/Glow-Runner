using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    private InputManager inputManager;
    private Vector3 targetPosition;
    private bool isMoving; // para que el juego espere que el player se mueva a yun lado para q se mueva al otro 

    public float lanesDistance = 1f; // distancia entre los carriles - entre enl centro y la posicion de la dereche o izq

    void Start()
    {
        inputManager = GetComponent<InputManager>();
        targetPosition = transform.position;
        isMoving = false;
    }

    private void SelectTargetPosition()
    {
        if (isMoving) { return; }

        float horizontalMovement = inputManager.horizontalMovement.ReadValue<float>();
        float x = transform.position.x;

        if (horizontalMovement == 1 && x <= 0)
        {
            targetPosition = transform.position + Vector3.right * lanesDistance;
            isMoving = true;
        }
        else if (horizontalMovement == -1 && x >= 0)
        {
            targetPosition = transform.position + Vector3.left * lanesDistance;
            isMoving = true;
        }
    }

    private void MoveToTargetPosition()
    {
        if (!isMoving) { return; }// Si no nos movemos no ejecutamos nada
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
        float distance = (targetPosition - transform.position).magnitude; // distancia entre el target position y la position del player
        
        if (distance < 0.001f)
        {
            transform.position = targetPosition;
            isMoving = false;
        }
    }
    void Update()
    {
        SelectTargetPosition();
        MoveToTargetPosition();
    }
}
 
