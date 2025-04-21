using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Vector3[] directions = { Vector3.right, Vector3.left };
    private int directionIndex = 0;
    private bool moveDown = false;
    private double timer = 0;

    void Update()
    {
        if (moveDown)
        {
            timer += Time.deltaTime;
            if (timer > 0.15)
            {
                moveDown = false;
                timer = 0;
                return;
            }
            transform.Translate(Vector3.down * (moveSpeed * Time.deltaTime));
            return;
        }
        
        transform.Translate(directions[directionIndex] * (moveSpeed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) return;
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            directionIndex = (directionIndex + 1) % 2;
            moveDown = true;
        }
    }
}
