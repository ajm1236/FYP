using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    //contains plaeyr health, max health, etc
    [System.Serializable]
    public class PlayerStatus 
    {
        public float currentHealth;
        public float maxHealth = 1f;

    }
    public PlayerStatus playerStatus = new PlayerStatus();
    public float fallDeath = -20f;
    public Shake camShake;
    public float shake = 0.1f;
    private void Start()
    {
        camShake = GameStuff.gameStuff.GetComponent<Shake>();
        if (camShake == null)
        {
            Debug.LogError("No shake script found in GameStuff!");
        }
        playerStatus.currentHealth = playerStatus.maxHealth;
    }

    //way of destorying player from falling,
    private void Update()
    {
        if(transform.position.y <= fallDeath)
        {
            HitPlayer(100000000);
        }
        if (playerStatus.currentHealth > 1)
        {
            playerStatus.currentHealth = 1f;
        }
    }

    //way of player receiving damage
    public void HitPlayer(float damage)
    {
        playerStatus.currentHealth -= damage;
        camShake.CameraShake(shake, 0.2f);

        if (playerStatus.currentHealth <=0)
        {
           GameStuff.DestroyPlayer(this);
        }
    }

}
