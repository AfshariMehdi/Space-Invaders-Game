using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Vector3[] directions = { Vector3.right, Vector3.left };
    private int directionIndex;
    private bool moveDown;
    private double timerForMoveDown;
    [SerializeField] GameObject enemyProjectile;
    double timerForProjectile = 0;

    void Awake()
    {
        directionIndex = 0;
        moveDown = false;
        timerForMoveDown = 0;
    }

    void Update()
    {
        if (moveDown)
        {
            timerForMoveDown += Time.deltaTime;
            if (timerForMoveDown > 0.15)
            {
                moveDown = false;
                timerForMoveDown = 0;
                return;
            }
            transform.Translate(Vector3.down * (moveSpeed * Time.deltaTime));
            return;
        }
        
        transform.Translate(directions[directionIndex] * (moveSpeed * Time.deltaTime));

        if (timerForProjectile > 1)
        {
            int randomInt = UnityEngine.Random.Range(1, transform.childCount);
            Instantiate(enemyProjectile, transform.GetChild(randomInt).position, Quaternion.identity);
            timerForProjectile = 0;
        }
        
        timerForProjectile += Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("EnemyProjectile")) return;
        
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            directionIndex = (directionIndex + 1) % 2;
            moveDown = true;
        }
    }
}
