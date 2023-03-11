using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; 
    [SerializeField] private float zoomSpeed = 5f; 
    [SerializeField] private float minZoom = 1f; 
    [SerializeField] private float maxZoom = 5f; 

    private Vector3 dragOrigin;

    void Update()
    {
        //pan
        if (Input.GetMouseButtonDown(2))
        {
            dragOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 delta = Input.mousePosition - dragOrigin;
            transform.position -= delta * Time.deltaTime * moveSpeed / transform.localScale.x;
            dragOrigin = Input.mousePosition;
        }

        //zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float zoomAmount = Mathf.Clamp(Camera.main.orthographicSize - scroll * zoomSpeed, minZoom, maxZoom);
        Camera.main.orthographicSize = zoomAmount;
    }
}
