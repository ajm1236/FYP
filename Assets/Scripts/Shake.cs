using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Camera mainCamera;
    private float amount = 0;

    private void Awake()
    {
        if(mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }
    public void CameraShake(float numberOf, float duration)
    {
        amount = numberOf;
        InvokeRepeating("StartShake", 0, 0.01f);
        Invoke("EndShake", duration);
    }

    void StartShake()
    {
        if(amount > 0)
        {
            Vector3 pos = mainCamera.transform.position;
            //offset values
            float x = Random.value * amount * 2 - amount;
            float y = Random.value * amount * 2 - amount;
            pos.x += x;
            pos.y += y;
            mainCamera.transform.position = pos;
        }
    }

    void EndShake()
    {
        CancelInvoke("StartShake");
        mainCamera.transform.localPosition = Vector3.zero;
    }
}
