using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Health")]
public class PowerUpHealth : PowerUp
{
    public PlayerInfo health;
    public float healthAmount;

    public override void Power(GameObject target)
    {
        target.GetComponent<PlayerInfo>().playerStatus.currentHealth += healthAmount;

    }
}
