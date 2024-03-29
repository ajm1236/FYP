using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PowerUp effect;
    public HealthBar bar;
    public PlayerInfo health;

    //for regaulr power ups to be able to be "picked up"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bar.SetSize(health.playerStatus.currentHealth);
            Destroy(gameObject);
            effect.Power(collision.gameObject);
        }
    }
}
