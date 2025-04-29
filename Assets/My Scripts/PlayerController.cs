using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerMoveSpeed;
    [SerializeField] Vector2 movementInput;
    
    [SerializeField] GameObject projectile;
    public AudioClip fireSound;
    private AudioSource audioSource;
    
    private int lives = 3;
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private GameObject explosion;
    
    public static bool isDead = false;
    
    public static bool isPaused;
    private double puaseTime;
    
    void Start()
    {
        isPaused = false;
        playerMoveSpeed = 5f;
        if (SkinSelector.selectedSprite != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SkinSelector.selectedSprite;
        }
        
        audioSource = GetComponent<AudioSource>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    
    public void onFire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameObject newProjactile = Instantiate(projectile, transform.position 
                + new Vector3(0, transform.localScale.y * 2.6f, 0) , Quaternion.identity);
            Destroy(newProjactile, 2f);

            audioSource.time = 0.6f;
            audioSource.PlayOneShot(fireSound);
        }
    }

    void Update()
    {
        if (isPaused)
        {
            puaseTime += Time.deltaTime;
            if (puaseTime >= 2f)
            {
                isPaused = false;
                puaseTime = 0f;
            }
            return;
        }
        
        if (isDead)
        {
            Debug.Log("Dead");
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
            GameObject e = Instantiate(explosion, transform.position, Quaternion.identity);
            e.transform.localScale = new Vector3(1f, 1f, -1f);
            Destroy(e, 0.3f);
            
        }
    }

    void TakeDamage()
    {
        isPaused = true;
        lives--;

        UpdateHearts();

        if (lives <= 0)
        {
            isDead = true;
        }
    }

    void UpdateHearts()
    {
        Destroy(hearts[lives]);
    }
}