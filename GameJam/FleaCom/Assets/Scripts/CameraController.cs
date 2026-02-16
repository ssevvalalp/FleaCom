using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float CameraSpeed = 10f;
    private void Update()
    {
        HandleCamera();
    }

    private void HandleCamera()
    {
        Vector2 inputDir = new Vector2(0, 0);
        int edgeScrollSize = 20;

        if (Input.mousePosition.y < edgeScrollSize) inputDir.y = -1f;
        if (Input.mousePosition.x < edgeScrollSize) inputDir.x = -1f;
        if (Input.mousePosition.y > Screen.height - edgeScrollSize) inputDir.y = +1f;
        if (Input.mousePosition.x > Screen.width - edgeScrollSize) inputDir.x = +1f;

        transform.position += new Vector3(inputDir.x, inputDir.y, 0f) * CameraSpeed * Time.deltaTime;
    }
}
