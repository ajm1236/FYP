using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    AudioController controller;

    public void Exit()
    {
        controller.Boombox("MenuMusic");
        SceneManager.LoadScene("Menu_Screen");

    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
