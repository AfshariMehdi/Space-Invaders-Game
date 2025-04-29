using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    void Update()
    {
        if (PlayerController.isPaused) return;
        
        transform.Translate(Vector2.down * (moveSpeed * Time.deltaTime));
        Destroy(gameObject, 4f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Projectile") 
            || other.gameObject.CompareTag("downWall")) return;
        Destroy(gameObject);
    }
}
