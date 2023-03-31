using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    // feet collide with this and destroy the enemy 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weak Point") 
        {
            Destroy(collision.gameObject);
        }
    }
}
