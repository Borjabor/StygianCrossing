using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    public float zoomDistance = 2f;
    public float zoomSpeed = 5f;
    public Transform zoomPoint;
    
    private Camera mainCamera;
    private bool isZooming = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject objectHit = hit.transform.gameObject;

                // Check if the clicked object is this object
                if (objectHit == gameObject)
                {
                    // Set the zooming flag
                    isZooming = true;

                    // Store the original position and rotation of the object
                    originalPosition = transform.position;
                    originalRotation = transform.rotation;
                }
            }
        }

        if (isZooming)
        {
            // Move the object towards the zoom point
            transform.position = Vector3.MoveTowards(transform.position, zoomPoint.position, zoomSpeed * Time.deltaTime);

            // If the object is close enough to the zoom point, stop moving and look at the camera
            if (Vector3.Distance(transform.position, zoomPoint.position) < zoomDistance)
            {
                transform.LookAt(mainCamera.transform);
            }
        }
        else
        {
            // Move the object back to its original position and rotation
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, zoomSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, originalRotation, zoomSpeed * Time.deltaTime * 100f);
        }
    }
}
