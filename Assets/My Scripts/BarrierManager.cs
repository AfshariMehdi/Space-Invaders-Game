using UnityEngine;

public class BarrierManager : MonoBehaviour
{

    private int health = 8;
    [SerializeField] Sprite[] healthSprites ;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void UpdateSprite()
    {
        if (health == 6) spriteRenderer.sprite = healthSprites[1];
        else if (health == 4) spriteRenderer.sprite = healthSprites[2];
        else if (health == 2) spriteRenderer.sprite = healthSprites[3];
    }

    void TakeDamage()
    {
        if (health <= 0) Destroy(gameObject);
        health--;
        UpdateSprite();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            TakeDamage();
        }
    }
}
