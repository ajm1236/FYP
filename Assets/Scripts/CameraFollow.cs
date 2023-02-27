using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float ahead = 1.5f;
    public float aheadSpeed = 0.5f;
    public float aheadMove = 0.1f;
    public float cameraDeathPos = -1;
    public float smooth = 0.2f;

    float offset;
    float findTime = 0;

    Vector3 velocity;
    Vector3 lastPos;
    Vector3 aheadPos;
    
    // Start is called before the first frame update
    void Start()
    {
        lastPos = target.position;
        offset = transform.position.z - target.position.z;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            GetNewPlayer();
            return;
        }

        //updates ahead position if accelerating or changing direction
        float moveX = target.position.x - lastPos.x;
        bool aheadTarget = Mathf.Abs(moveX) > aheadMove;

        if(aheadTarget)
        {
            aheadPos = ahead * Mathf.Sign(moveX) * Vector3.right;
        }
        else
        {
            aheadPos = Vector3.MoveTowards(aheadPos, Vector3.zero, Time.deltaTime * aheadSpeed);
        }

        Vector3 targetPos = (target.position + aheadPos + Vector3.forward * offset);
        targetPos.y += 6;
        Vector3 nicePos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smooth);
        nicePos = new Vector3(nicePos.x, Mathf.Clamp(nicePos.y, cameraDeathPos, Mathf.Infinity), nicePos.z);
        transform.position = nicePos;
        lastPos = target.position;
    }

    void GetNewPlayer()
    { 
        if(findTime <= Time.time)
        {
            GameObject found = GameObject.FindGameObjectWithTag("Player");
            if(found != null)
            {
                target = found.transform;
            }
            findTime = Time.time + 1f;
        }
    }
}
