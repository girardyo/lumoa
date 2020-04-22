using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public static bool IsGameEnded = false;

    public GameObject endMenuUI;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        else if (IsGameEnded)
        {
            Pause();
        }
       
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        IsGamePaused = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Debug.Log("game paused");
        if (IsGameEnded)
        {
            Debug.Log("show end menu");
            endMenuUI.SetActive(true);
        }  
        else
        {
            Debug.Log("show pause menu");
            pauseMenuUI.SetActive(true);
            IsGamePaused = true;
        }

        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        IsGameEnded = false;
        IsGamePaused = false;
        KeyCheckScript.ResetKeyChecker();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
