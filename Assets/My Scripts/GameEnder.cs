using UnityEngine;

public class GameEnder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerController.isDead = true;
        }
    }
}
