using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Vector2 newPos;
    GameObject[] platforms;
    public float distance = 0.286f;
    float count = 0f;

    private void Start()
    {
        newPos = new Vector2(transform.position.x, transform.position.y - distance);
        platforms = GameObject.FindGameObjectsWithTag("Destroy");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(count < 1f)
        {
            if (collision.transform.tag == "Player")
            {
                Debug.Log("player is here");
                transform.position = Vector2.Lerp(transform.position, newPos, 40f * Time.deltaTime);
                for(int i = 0; i < platforms.Length; i++)
                {
                    Destroy(platforms[i]);
                }
                count++;
            }
        }
        
    }
}
