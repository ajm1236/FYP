using UnityEngine;

public class BossFight : MonoBehaviour
{
    public int destroyed = 0;
    public Transform[] waypoints;

    void Start()
    {
        transform.GetComponent<BoxCollider2D>().enabled = false;
    }

    void FixedUpdate()
    {
        
        if (destroyed == 3)
        {
            Destroy(GameObject.FindGameObjectWithTag("BossDoor"));
        }
        if(Input.GetKey(KeyCode.K))
        {
            transform.localScale = new Vector2(2.5f, 2.5f);
            transform.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            transform.GetComponent<BoxCollider2D>().enabled = true;
            transform.GetComponent<EnemyMove>().speed = 20;
            transform.tag = "Weak Point";
            for (int i = 0; i < waypoints.Length; i++)
            {
                waypoints[i].position = new Vector2(waypoints[i].position.x, 1.69f);
            }
            transform.position = new Vector2(transform.position.x, transform.position.y + 5);
        }
    }
    public void DestroyedCount()
    {
        destroyed++;
        if (destroyed == 4)
        {
            Debug.Log("bono is a shit");
            transform.localScale = new Vector2(2.5f, 2.5f);
            transform.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            transform.GetComponent<BoxCollider2D>().enabled = true;
            transform.GetComponent<EnemyMove>().speed = 30;
            transform.tag = "Weak Point";
            for(int i = 0; i < waypoints.Length; i++)
            {
                waypoints[i].position = new Vector2(waypoints[i].position.x, 1.69f);
            }
            transform.position = new Vector2(transform.position.x, transform.position.y + 5);
        }
    }

    public void OnDestroy()
    {
        GameStuff.gameStuff.CompleteGame();
    }
}
