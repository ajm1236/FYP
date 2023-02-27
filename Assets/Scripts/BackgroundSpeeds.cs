using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpeeds : MonoBehaviour
{
    public Transform[] backgrounds;
    private float[] scales;
    public float smooth = 1f;

    private Transform mainCamera;
    private Vector3 lastCameraPos;

    private void Awake()
    {
        mainCamera = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        lastCameraPos = mainCamera.position;
        scales = new float[backgrounds.Length];
        for(int i = 0; i < backgrounds.Length; i++)
        {
            scales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (mainCamera.position.x - lastCameraPos.x) * scales[i];
            float targetBackPosX = backgrounds[i].position.x + parallax;
            Vector3 targetBackPos = new Vector3(targetBackPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetBackPos, smooth * Time.deltaTime);
        }

        lastCameraPos = mainCamera.position;

    }
}
