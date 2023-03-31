using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Speed")]
public class PowerUpSpeed : PowerUp
{
    public PlayerInfo player;
    public float speedBoost;
    public float cooldownTime;

    // increases player speed by a specific amount dependent on type of pickup
    public override void Power(GameObject target)
    {
        target.GetComponent<SpriteCharacter>().speed += speedBoost;
        
    }

}
