using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public PlayerInfo player;
    public SpriteCharacter sprite;
    public SpriteRenderer spriteRenderer;
    public float referenceVel;
    public float referenceJump;
    public float referenceGra;
    public float drown;
    public float drownSpeed;
    public float drownTime;

    private void Start()
    {
        sprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteCharacter>();
        spriteRenderer = GameObject.FindGameObjectWithTag("PlayerRenderer").GetComponent<SpriteRenderer>();
        referenceVel = 12.5f;
        referenceJump = 20f / 2;
        referenceGra = 7 / 2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            sprite.speed /= 2f;
            sprite.jump /= 2f;
            sprite.body.gravityScale /= 2f;
            spriteRenderer.color = new Color32(52, 147, 170, 255);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //make it so that the player loses health slowly after a while
            sprite.isCooldownWalk = true;
            drown += Time.deltaTime * drownSpeed;
            if(drown >= drownTime)
            {
                StartCoroutine(Drown());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            sprite.speed = 25f;
            sprite.jump = 40f;
            sprite.body.gravityScale *= 2;
            spriteRenderer.color = new Color(255, 255, 255, 255);
            sprite.isCooldownWalk = false;
            drown = 5;
            drownSpeed = 1;
            drownTime = 10;
        }
    }

    IEnumerator Drown()
    {
        player.HitPlayer(0.002f);
        yield return new WaitForSeconds(0.5f);
    }
}
