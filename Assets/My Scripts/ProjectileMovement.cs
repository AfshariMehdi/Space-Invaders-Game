using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float projectileSpeed;
    
    void Update()
    {
        transform.Translate(Vector2.up * (projectileSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }
}
