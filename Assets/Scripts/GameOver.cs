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
    public void OnDisable()
    {
        controller.ByeBoombox("End");

    }
    public void OnEnable()
    {
        controller.ByeBoombox("Background");

    }

    public void Exit()
    {
        controller.Boombox("MenuMusic");
        SceneManager.LoadScene("Menu_Screen");

    }

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
