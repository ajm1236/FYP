using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //key that destorys the hatch to progress in level 4
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(GameObject.FindGameObjectWithTag("Hatch"));
            Destroy(gameObject);
        }
    }
}
