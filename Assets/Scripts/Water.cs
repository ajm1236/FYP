using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float breathTime = 5f;
    float breathLeft;
    public RectTransform breath;
    public RectTransform border;
    Vector2 oldBreath;

    private void Start()
    {
        sprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteCharacter>();
        spriteRenderer = GameObject.FindGameObjectWithTag("PlayerRenderer").GetComponent<SpriteRenderer>();
        referenceVel = 12.5f;
        referenceJump = 20f / 2;
        referenceGra = 7 / 2;
        breathLeft = breathTime;
        breath.gameObject.SetActive(false);
        border.gameObject.SetActive(false);
        oldBreath = breath.localScale;
    }
    
    //enables breath bar, affects player gravity, speed, and jump, change colour to suit water
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            sprite.speed /= 2f;
            sprite.jump /= 2f;
            sprite.body.gravityScale /= 2f;
            spriteRenderer.color = new Color32(52, 147, 170, 255);
            breath.localScale = new Vector2(breathLeft / breathTime, oldBreath.y);
            border.localScale = new Vector2(breathLeft / breathTime, 4.829133f);
            breath.gameObject.SetActive(true);
            border.gameObject.SetActive(true);

        }
    }
    // damage player after they stay in water for too long 
    // breath bar decreases in size as countdown goes down 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //make it so that the player loses health slowly after a while
            sprite.isCooldownWalk = true;
            drown += Time.deltaTime * drownSpeed;
            breathLeft -= Time.deltaTime;
            breath.localScale = new Vector2(breathLeft / breathTime, oldBreath.y);
            if(drown >= drownTime)
            {
                StartCoroutine(Drown());
            }
            if(breathLeft <= 0)
            {
                breath.localScale = new Vector2(0,0);
            }
        }
    }
    //set everything back to normal
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
            breath.GetComponent<Image>().fillAmount = 1;
            breath.gameObject.SetActive(false);
            border.gameObject.SetActive(false);
            breath.localScale = oldBreath;
            breathLeft = breathTime;

        }
    }
    //rate at which player drowns
    IEnumerator Drown()
    {
        player.HitPlayer(0.002f);
        yield return new WaitForSeconds(0.5f);
    }
}
