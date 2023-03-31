using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStuff : MonoBehaviour
{
    public static GameStuff gameStuff;
    public Transform player, spawn, spawnEffect;
    public string soundName;
    public AudioController controller;
    public Timer time;
    public RectTransform[] UI;

    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject gameCompleteUI;

    void Awake()
    {
        if(gameStuff == null)
        {
            gameStuff = GameObject.FindGameObjectWithTag("GS").GetComponent<GameStuff>(); ;
        }
        Instantiate(spawnEffect, spawn.position, spawn.rotation); //spawn particle effect 
        controller = AudioController.controller; // set audio controller
        if(controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>(); ;
        }
        if(time == null)
        {
            time = GameObject.FindGameObjectWithTag("GS").GetComponent<Timer>(); ;
        }
    }

    //enable game over UI when called
    public void EndGame()
    {
        gameOverUI.SetActive(true);
        time.StopTimer();
    }

    //disable regular UI and set game complete UI
    public void CompleteGame()
    {
        gameCompleteUI.SetActive(true);
        time.StopTimer();
        for(int i = 0; i < UI.Length; i++)
        {
            UI[i].position = new Vector3(100000, 100000, 10000);
        }
        controller.Boombox("End");
        controller.ByeBoombox("Background");

    }

    //destory player 
    public static void DestroyPlayer(PlayerInfo player)
    {
        Destroy(player.gameObject);
        gameStuff.EndGame();
    }

    public static void DestroyEnemy(EnemyInfo enemy)
    {
        //controller.Boombox(soundName);
        Destroy(enemy.gameObject);
    }


}
