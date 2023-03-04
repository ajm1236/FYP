using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerInfo player;
    public HealthBar bar;
    public float damage; 
    public Shake camShake;
    public float shake = 0.2f;

     void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>(); ;
        bar = GameObject.FindGameObjectWithTag("Bar").GetComponent<HealthBar>(); ;
        camShake = GameStuff.gameStuff.GetComponent<Shake>();
        StartCoroutine(Timer());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            player.HitPlayer(damage);
            bar.SetSize(player.playerStatus.currentHealth);
            camShake.CameraShake(shake, 0.2f);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(6);
        Destroy(this.gameObject);
    }

}
