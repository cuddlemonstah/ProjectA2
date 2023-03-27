using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;

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
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
