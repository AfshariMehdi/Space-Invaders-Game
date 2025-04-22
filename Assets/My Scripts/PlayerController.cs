using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerMoveSpeed;
    [SerializeField] Vector2 movementInput;
    
    [SerializeField] GameObject projectile;
    
    private int health = 3;
    private Image image;
    [SerializeField] Sprite[] healthSprites ;
    [SerializeField] GameObject lives;
    
    private bool isDead = false;

    void Awake()
    {
        playerMoveSpeed = 5f;
        image = lives.GetComponent<Image>();  
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            TakeDamage();
        }
    }
    
    void UpdateSprite()
    {
        if (health == 2) image.sprite = healthSprites[1];
        else if (health == 1) image.sprite = healthSprites[2];
    }

    void TakeDamage()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            isDead = true;
        }
        health--;
        UpdateSprite();
    }
}