using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float damage;
    public float slow;
    public float shake = 0.1f;
    public float cooldown = 0.2f;
    float _lastAttack;


    public PlayerInfo health;
    public SpriteCharacter movement;
    public HealthBar bar;
    public Shake camShake;

    //slows player down in spikes 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        movement.speed = movement.speed / 2f;
        movement.jump = movement.jump / 1.2f;
    }

    //deals damage on a cooldown basis 
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time - _lastAttack < cooldown) return;

        if (collision.gameObject.tag == "Player")
        {

            health.HitPlayer(damage);
            bar.SetSize(health.playerStatus.currentHealth);
            camShake.CameraShake(shake, 0.2f);
            _lastAttack = Time.time;
        }
    }

    //reset movement speeds
    private void OnCollisionExit2D(Collision2D collision)
    {
        movement.speed = movement.speed * 2f;
        movement.jump = movement.jump * 1.2f;
        bar.SetSize(health.playerStatus.currentHealth);

    }

}
