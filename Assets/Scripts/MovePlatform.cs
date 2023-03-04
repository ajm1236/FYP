using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public int targetPos;
    public PlayerInfo player;
    bool moving;


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.collider.attachedRigidbody.interpolation = RigidbodyInterpolation2D.None;
            //collision.collider.transform.SetParent(transform);
            player.transform.SetParent(transform);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.collider.attachedRigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;
            //collision.collider.transform.SetParent(null);
            player.transform.SetParent(null);


        }
    }
}
