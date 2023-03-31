using UnityEngine;

public class BackgroundSpeeds : MonoBehaviour
{
    public Transform[] backgrounds; // background images, foregorund, etc
    private float[] scales; // control background movement 
    public float smoothing = 1f; //control movement speed

    private Transform mainCamera;
    private Vector3 lastCameraPos;

    private void Awake()
    {
        mainCamera = Camera.main.transform;
    }

    void Start()
    {
        lastCameraPos = mainCamera.position;
        scales = new float[backgrounds.Length];
        for(int i = 0; i < backgrounds.Length; i++)
        {
            scales[i] = backgrounds[i].position.z * -1; // z is negated, so that the larger the z-position, the slower the movement of the background layer
                                                        // further away the postition the slower it will move
        }
    }

    void Update()
    {
        // loop through each background layer
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (mainCamera.position.x - lastCameraPos.x) * scales[i]; // calculate the parallax effect for layer based on camera movement
            float targetBackPosX = backgrounds[i].position.x + parallax; // calculate the target x-pos of layer based on the parallax effect
            Vector3 targetBackPos = new Vector3(targetBackPosX, backgrounds[i].position.y, backgrounds[i].position.z); // new target pos with parallax effect
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetBackPos, smoothing * Time.deltaTime); // move the layer toward position dependent on smoothing factor
        }

        lastCameraPos = mainCamera.position; //update camera pos for next frame

    }
}
