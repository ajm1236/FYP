using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public static bool isPaused;
    private void Start()
    {
        pause.SetActive(false);
    }

    // time set to 0 to resume game, UI object in editor set to inactive
    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    // time set to 0 to pause game, UI object in editor set to active
    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    //main menu button
    public void MainMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu_Screen");
    }
    
    //quit game button
    public void QuitGame()
    {
        Application.Quit();
    }

    //key to enable pause
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

}

