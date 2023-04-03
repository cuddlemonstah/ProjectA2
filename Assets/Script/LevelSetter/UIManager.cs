using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject playerShooting;
    public GameObject pauseMenuUI;
    public GameObject gameOverMenu;
    public static bool GameIsPaused = false;

    //!Death
    private void OnEnable()
    {
        PlayerController.OnPlayerDeath += EnableGameOverMEnu;
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerDeath -= EnableGameOverMEnu;
    }
    public void EnableGameOverMEnu()
    {
        gameOverMenu.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
        Resume();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ResBut()
    {
        Resume();
    }
    public void Exit()
    {
        Application.Quit();
    }

    //!Pause Menu
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        playerShooting.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    void Resume()
    {
        playerShooting.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
