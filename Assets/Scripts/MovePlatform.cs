using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public int targetPos;
    public PlayerInfo player;

    // tries to move platform to next waypoint over a certain amount of time
    void Update()
    {
        try { 
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
        catch
        {
            return;
        }
    }

    // sets the interpolation of player rigidbody to none so the player can freely move on platform
    // sets player as child of platform to allow platform to carry player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.collider.attachedRigidbody.interpolation = RigidbodyInterpolation2D.None;
            player.transform.SetParent(transform);
        }
    }

    //opposite of above to set everything back to normal
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.collider.attachedRigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;
            player.transform.SetParent(null);
        }
    }
}
