using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera _camera;
    private float _zoomTarget;

    [SerializeField]
    private float multiplier = 2f, minZoom = 1f, maxZoom = 10f, smoothTime = .1f, velocity = 0f;
    
    void Start()
    {
        _camera = GetComponent<Camera>();
        _zoomTarget = _camera.orthographicSize;
    }

 
    void Update()
    {
        _zoomTarget -= Input.GetAxisRaw("Mouse ScrollWheel") * multiplier;
        _zoomTarget = Mathf.Clamp(_zoomTarget, minZoom, maxZoom);
        _camera.orthographicSize = Mathf.SmoothDamp(_camera.orthographicSize, _zoomTarget, ref velocity, smoothTime);
    }
}
