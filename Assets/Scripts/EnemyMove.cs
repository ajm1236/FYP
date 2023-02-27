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
    bool isRight = false;


    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) < trackDistance)
        {
            
            if (transform.position.x > player.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += Vector3.left * speed * Time.deltaTime;

            }
            if (transform.position.x < player.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
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

        void Flip()
        {
            isRight = !isRight;
            Vector3 tmpScale = gameObject.transform.localScale;
            tmpScale.x *= -1;
            gameObject.transform.localScale = tmpScale;
        }
    }
    

}