using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    AudioController controller;
    private void Start()
    {
        controller = AudioController.controller;
        if(controller == null)
        {
            Debug.LogError("No AudioController instance found");
        }
        controller.Boombox("MenuMusic");


    }
    public Animator fade;
    public float fadeTime = 1f;
    public void GameStart()
    {
        //SceneManager.LoadScene("Game");
        controller.ByeBoombox("MenuMusic");
        StartCoroutine(FadeLevel());
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void MouseHover()
    {
        controller.Boombox("Hover");
    }
    public void MousePress()
    {
        controller.Boombox("Press");
    }

    IEnumerator FadeLevel ()
    {
        fade.SetTrigger("Start");
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("Game");

    }

}
