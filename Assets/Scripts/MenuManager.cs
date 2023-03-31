using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    AudioController controller;
    private void Awake()
    {
        controller = AudioController.controller;
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>(); ;
        }
        controller.Boombox("MenuMusic");
    }

    public Animator fade; //fad animate the start of the game 
    public float fadeTime = 1f;

    //the following enables sounds based on what the context is 

    public void GameStart()
    {
        controller.ByeBoombox("MenuMusic");
        StartCoroutine(FadeLevel());
        controller.Boombox("Background");
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
