using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Health")]
public class PowerUpHealth : PowerUp
{
    public PlayerInfo health;
    public float healthAmount;

    // increases player health by a specific amount dependent on type of pickup
    public override void Power(GameObject target)
    {
        target.GetComponent<PlayerInfo>().playerStatus.currentHealth += healthAmount;

    }
}
