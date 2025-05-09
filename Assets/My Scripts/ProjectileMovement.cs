using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float projectileSpeed;
    
    [SerializeField] GameObject EnemyExplosion;

    private ScoreManager scoreManager;
    
    void Update()
    {
        if (PlayerController.isPaused) return;
        
        transform.Translate(Vector2.up * (projectileSpeed * Time.deltaTime));
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            scoreManager.AddScore();
            Destroy(collision.gameObject);
            GameObject e = Instantiate(EnemyExplosion, transform.position, Quaternion.identity);
            Destroy(e, 0.3f);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }
}
