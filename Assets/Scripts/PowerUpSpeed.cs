using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Speed")]
public class PowerUpSpeed : PowerUp
{
    public PlayerInfo player;
    public float speedBoost;
    float og, effect;
    public float cooldownTime;
    float lastTime = 0;



    public override void Power(GameObject target)
    {
        og = target.GetComponent<SpriteCharacter>().speed;
        target.GetComponent<SpriteCharacter>().speed += speedBoost;
        
    }

}
