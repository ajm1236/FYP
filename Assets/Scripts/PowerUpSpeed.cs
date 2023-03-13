using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Speed")]
public class PowerUpSpeed : PowerUp
{
    public PlayerInfo player;
    public float speedBoost;
    public float cooldownTime;

    public override void Power(GameObject target)
    {
        target.GetComponent<SpriteCharacter>().speed += speedBoost;
        
    }

}
