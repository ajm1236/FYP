using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    PlayerInfo player;
    float timer;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>(); 
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < radius)
        {
            timer += Time.deltaTime;
            if (timer > 1.25)
            {
                timer = 0;
                Shoot();
            }
        }
        
    }
    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, Quaternion.identity);
    }
}
