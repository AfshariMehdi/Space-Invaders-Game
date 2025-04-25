using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinChoice : MonoBehaviour
{
    public void OnClick()
    {
        Image image = GetComponent<Image>();
        if (image != null)
        {
            SkinSelector.selectedSprite = image.sprite;
            SceneManager.LoadScene("Game");
        }
    }
}