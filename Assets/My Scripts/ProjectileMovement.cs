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
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
