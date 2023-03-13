using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] waypoints;
    public float speed;
    public int targetPos;


    public Transform player;
    public bool isTracking;
    public float trackDistance;
    float scalex, scalez, scaley;

    private void Awake()
    {
        scalex = transform.localScale.x;
        scaley = transform.localScale.y;
        scalez = transform.localScale.z;
    }
    
    // Update is called once per frame
    void Update()
    {
       
        if(Vector2.Distance(transform.position, player.position) < trackDistance)
        {
            
            if (transform.position.x > player.position.x)
            {
                transform.localScale = new Vector3(scalex, scaley, scalez);
                transform.position += Vector3.left * speed * Time.deltaTime;

            }
            if (transform.position.x < player.position.x)
            {
                transform.localScale = new Vector3(-scalex, scaley, scalez);
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else
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

}
