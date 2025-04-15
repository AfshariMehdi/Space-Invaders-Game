using System;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float projectileSpeed = 12f;

    void Update()
    {
        transform.Translate(Vector2.up * (projectileSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        throw new NotImplementedException();
    }
}
