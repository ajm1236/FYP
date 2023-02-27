using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public float damage;
    public float shake = 0.1f;
    
    public PlayerInfo health;
    public SpriteCharacter movement;
    public HealthBar bar;
    public float cooldown = 0.8f;
    float _lastAttack;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time - _lastAttack < cooldown) return;

        if (collision.gameObject.tag == "Player")
        {
            
            movement.knockCount = movement.knockTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                movement.knockRight = true;
            }
            else
            {
                movement.knockRight = false;
            }
            health.HitPlayer(damage);
            bar.SetSize(health.playerStatus.currentHealth);
            //camShake.CameraShake(shake, 0.2f);


        }
    }

}
