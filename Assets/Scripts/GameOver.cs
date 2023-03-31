using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOver : MonoBehaviour
{
    public AudioController controller;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI displayTimer;

    private void Update()
    {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>(); ;
        }
        displayTimer.text = timer.text;

    }
    //turn music off when game over screen is navigated away from 
    public void OnDisable()
    {
        controller.ByeBoombox("End");

    }
    //turn off background music when game ends
    public void OnEnable()
    {
        controller.ByeBoombox("Background");

    }
    // load menu scene and turn menu music on
    public void Exit()
    {
        controller.Boombox("MenuMusic");
        SceneManager.LoadScene("Menu_Screen");

    }
    // restart game music and load game
    public void Restart()
    {
        controller.Boombox("Background");
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
