using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform bar;
    private Image barImage;
    public PlayerInfo player;



    void Awake()
    {
        bar = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
    }
    
    public void SetSize(float size)
    {
        bar.localScale = new Vector2(size, 1f);
        if(size >= 1.001f)
        {
            size = 1;
            bar.localScale = new Vector2(size, 1f);
        }
        if(size <= 0.5f)
        {
            barImage.color = new Color32(255, 165, 0, 100);
        }
        if(size <= 0.3f)
        {
            barImage.color = Color.red;
        }
        if(size <= 0.0f)
        {
            barImage.color = Color.gray;
        }

    }


    private void Update()
    {
        SetSize(player.playerStatus.currentHealth);
    }
}
