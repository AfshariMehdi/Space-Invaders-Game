using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManagment : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        string scene = SceneManager.GetActiveScene().name;
        if (scene != "StartMenu" && scene != "ChooseSkin") Destroy(gameObject);
    }
}