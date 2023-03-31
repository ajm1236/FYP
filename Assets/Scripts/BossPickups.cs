using UnityEngine;

public class BossPickups : MonoBehaviour
{
    public BossFight boss;

    // if boss item interacted by player destroy it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            boss.DestroyedCount();
        }
    }
}
