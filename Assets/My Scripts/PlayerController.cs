using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movementInput;
    
    public float projectileSpeed = 8f;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("Move Input: " + context.ReadValue<Vector2>());
        movementInput = context.ReadValue<Vector2>();
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
            Debug.Log("Bang");
        }
    }

    void Update()
    {
        Vector2 movement = new Vector2(movementInput.x, 0);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

    }
}
