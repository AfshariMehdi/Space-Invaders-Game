using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Enemies;

    private void Start()
    {
        Instantiate(Enemies, transform.position, Quaternion.identity);
    }
}
