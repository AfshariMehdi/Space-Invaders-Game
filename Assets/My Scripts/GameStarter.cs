using UnityEngine;

public class GameStarter : MonoBehaviour
{ 
    public GameObject blueAliens;
    public GameObject redAliens;
    public GameObject greenAliens;

    private GameObject[] enemies;
    [SerializeField] float EnemyMoveSpeed;
    
    Vector3[] directions = { Vector3.right, Vector3.down, Vector3.left, Vector3.up, Vector3.right };
    float[] durations; // rectangle shape (adjust as you like)
    int directionIndex = 0;
    float timer = 0f;
    Vector3 direction;
    
    void Start()
    {
        for (int i = -5; i < 5; i++)
        {
            Instantiate(blueAliens, new Vector3(i, 5, 0), Quaternion.identity);
        }

        for (int i = -5; i < 5; i++)
        {
            Instantiate(redAliens, new Vector3(i, 4, 0), Quaternion.identity);
        }
        for (int i = -5; i < 5; i++)
        {
            Instantiate(redAliens, new Vector3(i, 3, 0), Quaternion.identity);
        }

        for (int i = -5; i < 5; i++)
        {
            Instantiate(greenAliens, new Vector3(i, 2, 0), Quaternion.identity);
        }
        for (int i = -5; i < 5; i++)
        {
            Instantiate(greenAliens, new Vector3(i, 1, 0), Quaternion.identity);
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        direction = directions[directionIndex];
        
        durations = new float[] {
            6f / EnemyMoveSpeed,  // right
            2f / EnemyMoveSpeed,  // down
            12f / EnemyMoveSpeed,  // left
            2f / EnemyMoveSpeed,  // up
            6f / EnemyMoveSpeed,  // second right
        };

        direction = directions[directionIndex];

    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= durations[directionIndex])
        {
            timer = 0f;
            directionIndex = (directionIndex + 1) % directions.Length;
            direction = directions[directionIndex];
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].transform.Translate(direction * (EnemyMoveSpeed * Time.fixedDeltaTime));
            }
        }
    }

}
