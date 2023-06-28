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
    public void BOL()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        float multiplyHealth = player.health * Artifacts[1].moveSpeed;
        player.health += Mathf.Ceil(multiplyHealth);
        resume();
    }
    public void BOW()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        float multiplyMana = player.mana * Artifacts[2].mana;
        player.mana += Mathf.Ceil(multiplyMana);
        resume();
    }
    public void Clock()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        float multiplyCoolDown = player.playerCoolDown * Artifacts[3].magicCoolDown;
        player.playerCoolDown += Mathf.Ceil(multiplyCoolDown);
        resume();
    }
    public void EW()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        float multiplyDamage = player.playerDamage * Artifacts[4].damage;
        player.playerDamage += Mathf.Ceil(multiplyDamage);
        resume();
    }
    public void HPot()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        float multiplyHRegen = player.healthRegen * Artifacts[5].healthRegen;
        player.healthRegen += Mathf.Ceil(multiplyHRegen);
        resume();
    }
    public void MPot()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        float multiplyMRegen = player.manaRegen * Artifacts[6].manaRegen;
        player.manaRegen += Mathf.Ceil(multiplyMRegen);
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
