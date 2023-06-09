using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject playerShooting;
    public GameObject pauseMenuUI;
    public GameObject gameOverMenu;
    public GameObject lvlUPS;
    public GameObject ArtifactChest;
    public static bool GameIsPaused = false;
    [SerializeField] public bool isEnabled = false;

    //!Death
    private void OnEnable()
    {
        PlayerController.OnPlayerDeath += EnableGameOverMEnu;
        PlayerController.OnPlayerLevelUp += enableLvlUpMenu;
        ChestBehaviour.OnPlayerTrigger += enableArtifactMenu;

    }
    private void OnDisable()
    {
        PlayerController.OnPlayerDeath -= EnableGameOverMEnu;
        ChestBehaviour.OnPlayerTrigger -= enableArtifactMenu;
    }
    public void EnableGameOverMEnu()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartLevel()
    {
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(1);
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
    public void enableLvlUpMenu()
    {
        isEnabled = true;
        lvlUPS.SetActive(true);
        WorldPause();
    }

    public void enableArtifactMenu()
    {
        isEnabled = true;
        ArtifactChest.SetActive(true);
        WorldPause();
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
                GamePause();
            }
        }
    }

    void GamePause()
    {
        pauseMenuUI.SetActive(true);
        playerShooting.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    void WorldPause()
    {
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
