using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private float Count;
    
    private Vector3[] directions = { Vector3.right, Vector3.left };
    private int directionIndex;
    
    private bool moveDown;
    private double timerForMoveDown;
    
    [SerializeField] GameObject enemyProjectile;
    double timerForProjectile;
    
    public static bool isWon;
    

    void Awake()
    {
        Count = 3;
        directionIndex = 0;
        moveDown = false;
        timerForMoveDown = 0;
        timerForProjectile = 0;
        isWon = false;
    }

    void Update()
    {
        if (PlayerController.isPaused) return;
        
        if (transform.childCount == 0)
        {
            isWon = true;
        }
        
        if (moveDown)
        {
            timerForMoveDown += Time.deltaTime;
            if (timerForMoveDown > 0.3)
            {
                moveDown = false;
                timerForMoveDown = 0;
                Count += 0.5f;
                return;
            }
            transform.Translate(Vector3.down * (moveSpeed * Time.deltaTime));
            return;
        }
        
        transform.Translate(directions[directionIndex] * (moveSpeed * (int)(Count/2) * Time.deltaTime));

        timerForProjectile += Time.deltaTime;
        if (timerForProjectile > 1)
        {
            int randomInt = Random.Range(0, transform.childCount);
            Instantiate(enemyProjectile, transform.GetChild(randomInt).position, Quaternion.identity);
            timerForProjectile = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("EnemyProjectile")
                                                          || collision.gameObject.CompareTag("Player")) return;
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            directionIndex = (directionIndex + 1) % 2;
            moveDown = true;
        }
    }
}
