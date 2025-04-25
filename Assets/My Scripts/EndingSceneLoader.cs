using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneLoader : MonoBehaviour
{

    void Start()
    {
        PlayerController.isDead = false;
        EnemiesMovement.isWon = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Home()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
