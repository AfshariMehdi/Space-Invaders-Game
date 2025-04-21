using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Vector3[] directions = { Vector3.right, Vector3.down, Vector3.left, Vector3.up };
    private int directionIndex = 0;
    private int counter = 0;

    void Update()
    {
        if (counter % 9 == 5) moveSpeed = 3;
        else if (counter % 9 == 0) moveSpeed = 2;
        transform.Translate(directions[directionIndex] * (moveSpeed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) return;
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            directionIndex = (directionIndex + 1) % 4;
            counter = (counter + 1) % 9;
        }
    }
}
