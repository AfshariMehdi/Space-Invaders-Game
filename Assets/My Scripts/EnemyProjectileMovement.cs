using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    void Update()
    {
        transform.Translate(Vector2.down * (moveSpeed * Time.deltaTime));
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) return;
        Destroy(gameObject);
    }
}
