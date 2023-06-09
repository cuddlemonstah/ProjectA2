using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateArtif : MonoBehaviour
{
    [SerializeField] private ArtifactStats[] Artifacts;
    void Start()
    {
    }
    //?its for the artifact sheet... the buttons in the lvlup prefab
    public void Boots()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        float multiplySpeed = player.speed * Artifacts[0].moveSpeed;
        player.speed += Mathf.Ceil(multiplySpeed);
        resume();
    }

    private void resume()
    {
        UIManager manage = FindObjectOfType<UIManager>();
        manage.isEnabled = false;
        manage.ArtifactChest.SetActive(false);
        manage.playerShooting.SetActive(true);
        Time.timeScale = 1f;
        UIManager.GameIsPaused = false;
    }
}
