using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCrest : MonoBehaviour
{
    public Image crest;
    public Sprite[] counties;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Dublin")
        {
            crest.sprite = counties[0];
        }
        if (collision.transform.tag == "Kerry")
        {
            crest.sprite = counties[1];
        }
    }
}