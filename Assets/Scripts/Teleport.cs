using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform destination;
    public PlayerInfo player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            player.transform.position = destination.position;
        }
    }
}
