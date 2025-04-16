using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerMoveSpeed;
    [SerializeField] Vector2 movementInput;
    
    [SerializeField] GameObject projectile;

    void Awake()
    {
        playerMoveSpeed = 5f;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("Movement input: " + context.ReadValue<Vector2>());
        movementInput = context.ReadValue<Vector2>();
    }
    
    public void onFire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameObject newProjactile = Instantiate(projectile, transform.position + new Vector3(0, 0.6f, 0), Quaternion.identity);
            Destroy(newProjactile, 2f);
        }
    }
    
    void Update()
    {
        Vector2 direction = new Vector2(movementInput.x, movementInput.y);
        transform.Translate(direction * (playerMoveSpeed * Time.deltaTime));
    }
}