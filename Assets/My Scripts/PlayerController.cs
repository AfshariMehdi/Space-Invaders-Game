using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerMoveSpeed;
    [SerializeField] Vector2 movementInput;
    
    [SerializeField] GameObject projectile;
    
    private int lives = 3;
    [SerializeField] private GameObject[] hearts;
    
    public static bool isDead = false;

    void Start()
    {
        playerMoveSpeed = 5f;
        if (SkinSelector.selectedSprite != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SkinSelector.selectedSprite;
        }
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
        if (isDead)
        {
            SceneManager.LoadScene("LooseScene");
        }

        if (EnemiesMovement.isWon)
        {
            SceneManager.LoadScene("WinScene");
        }
        
        Vector2 direction = new Vector2(movementInput.x, movementInput.y);
        transform.Translate(direction * (playerMoveSpeed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        if (lives <= 0)
        {
            isDead = true;
        }
        else
        {
            UpdateHearts();
            lives--;
        }
    }

    void UpdateHearts()
    {
        Destroy(hearts[lives - 1]);
    }
}