using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    PlayerInfo player;
    float timer;
    public float radius;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>(); 
    }

    void Update()
    { 
        float distance = Vector2.Distance(transform.position, player.transform.position); // calculate player distance 
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
        Instantiate(bullet, firePoint.position, Quaternion.identity); // instantiate a bullet with relative rotation (adjusts rotation in direction its heading)
    }
}
