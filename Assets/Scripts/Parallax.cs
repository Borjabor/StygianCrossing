using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] 
    private Transform[] backgrounds;   
    [SerializeField] 
    public float[] parallaxScales;   
    public float smoothing = 1f;     

    private Transform cam;            
    private Vector3 previousCamPos;   

    void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {
        previousCamPos = cam.position;
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;
            
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Fade between current position and the target position using smoothing
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Set the previousCamPos to the camera's position at the end of the frame
        previousCamPos = cam.position;
    }
}
