using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStuff : MonoBehaviour
{
    public static GameStuff gameStuff;
    public Transform player, spawn, spawnEffect;
    public string soundName; 
    [SerializeField]
    private GameObject gameOverUI;
    private AudioController controller;

    void Awake()
    {
        if(gameStuff == null)
        {
            gameStuff = GameObject.FindGameObjectWithTag("GS").GetComponent<GameStuff>(); ;
        }
        Instantiate(spawnEffect, spawn.position, spawn.rotation);
        controller = AudioController.controller;
        if(controller == null)
        {
            Debug.LogError("Lol theres no one to control the audio what are we going to do :(");
        }
    }

    public void EndGame()
    {
        gameOverUI.SetActive(true);
    }

    public static void DestroyPlayer(PlayerInfo player)
    {
        //controller.Boombox(soundName);
        Destroy(player.gameObject);
        //Debug.Log("player Destroyed");
        gameStuff.EndGame();
        //gameStuff.StartCoroutine(gameStuff.RespawnPlayer());

    }

    public static void DestroyEnemy(EnemyInfo enemy)
    {
        //controller.Boombox(soundName);
        Destroy(enemy.gameObject);
    }


}
