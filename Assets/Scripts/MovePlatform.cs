using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public int targetPos;


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[targetPos].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoints[targetPos].position) < 0.5f)
        {
            targetPos++;
        }
        if (targetPos >= waypoints.Length)
        {
            targetPos = 0;
        }
    }
}
