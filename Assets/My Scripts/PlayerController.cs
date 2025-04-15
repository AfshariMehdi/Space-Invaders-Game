using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movePlayerSpeed;
    
    public GameObject projectile;

    void Awake()
    {
        movePlayerSpeed = 5f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * (movePlayerSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * (movePlayerSpeed * Time.deltaTime));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newProjectile = Instantiate(projectile, transform.position + new Vector3 (0, 0.3f, 0), Quaternion.identity);
            Destroy(newProjectile, 2.5f);
        }

    }
}