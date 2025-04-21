using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
}