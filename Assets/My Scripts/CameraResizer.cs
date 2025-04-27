using UnityEngine;

public class CameraResizer : MonoBehaviour
{
    public float targetAspect = 16f / 9f;
    public float orthographicSize = 8f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        ResizeCamera();
    }

    void ResizeCamera()
    {
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            cam.orthographicSize = orthographicSize / scaleHeight;
        }
        else
        {
            cam.orthographicSize = orthographicSize;
        }
    }
}