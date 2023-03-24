using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    PlayerInfo player;
    HealthBar bar;
    Shake camShake;
    Rigidbody2D rb;
    public float damage;
    public float force;
    public float shake = 0.2f;
    float timer;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>(); ;
        bar = GameObject.FindGameObjectWithTag("Bar").GetComponent<HealthBar>();
        camShake = GameStuff.gameStuff.GetComponent<Shake>();
        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = player.transform.position - transform.position;
        //normalise to ensure direction stays same (length stays as 1)
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        //getting angle
        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 270);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.HitPlayer(damage);
            bar.SetSize(player.playerStatus.currentHealth);
            camShake.CameraShake(shake, 0.2f);
            Destroy(gameObject);
        }

    }
}
