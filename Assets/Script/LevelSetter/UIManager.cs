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
    public GameObject Shield;
    public static bool GameIsPaused = false;
    [SerializeField] public bool isEnabled = false;

    //!Death
    private void OnEnable()
    {
        PlayerController.OnPlayerDeath += EnableGameOverMEnu;
        PlayerController.OnPlayerLevelUp += enableLvlUpMenu;
        ChestBehaviour.OnPlayerTrigger += enableArtifactMenu;
        ShieldBehaviour.OnPlayerShield += EnableShield;
        ShieldBehaviour.DisablePlayerShield += DisableShield;
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerDeath -= EnableGameOverMEnu;
        PlayerController.OnPlayerLevelUp -= enableLvlUpMenu;
        ChestBehaviour.OnPlayerTrigger -= enableArtifactMenu;
        ShieldBehaviour.OnPlayerShield -= EnableShield;
        ShieldBehaviour.DisablePlayerShield -= DisableShield;
    }

    public void EnableShield()
    {
        Shield.SetActive(true);
    }
    public void DisableShield()
    {
        Shield.SetActive(false);
    }
    public void EnableGameOverMEnu()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
