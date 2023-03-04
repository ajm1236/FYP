using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float radius;
    public float fireRate;
    public float force;
    public Transform player;
    public GameObject alarm;
    public GameObject gun;
    public GameObject bullet;
    public Transform firePoint;
    bool inRange = false;
    float shootTime = 0;
    Vector2 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = player.position;
        direction = targetPos - (Vector2)transform.position;
        RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, radius);

        if(ray)
        {
            if (ray.collider.gameObject.CompareTag("Player"))
            {
                if(inRange == false)
                {
                    inRange = true;
                    alarm.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
            else
            {
                if (inRange == true)
                {
                    inRange = false;
                    alarm.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
        }

        if(inRange)
        {
            gun.transform.up = -direction;
            if(Time.time> shootTime)
            {
                shootTime = Time.time +1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject inst = Instantiate(bullet, firePoint.position, Quaternion.identity);
        inst.GetComponent<Rigidbody2D>().AddForce(direction * force);
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
