using UnityEngine;

public class GameStarter : MonoBehaviour
{ 
    public GameObject blueAliens;
    public GameObject redAliens;
    public GameObject greenAliens;
    void Start()
    {
        for (int i = -5; i < 5; i++)
        {
            Instantiate(blueAliens, new Vector3(i, 4, 0), Quaternion.identity);
        }

        for (int i = -5; i < 5; i++)
        {
            Instantiate(redAliens, new Vector3(i, 3, 0), Quaternion.identity);
        }
        for (int i = -5; i < 5; i++)
        {
            Instantiate(redAliens, new Vector3(i, 2, 0), Quaternion.identity);
        }

        for (int i = -5; i < 5; i++)
        {
            Instantiate(greenAliens, new Vector3(i, 1, 0), Quaternion.identity);
        }
        for (int i = -5; i < 5; i++)
        {
            Instantiate(greenAliens, new Vector3(i, 0, 0), Quaternion.identity);
        }
    }
}
