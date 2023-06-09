using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAp : MonoBehaviour
{

    [SerializeField] private AttackStats[] Atks;
    void Start()
    {
    }
    //?its for the ability sheet... the buttons in the lvlup prefab
    public void Fireball()
    {
        if (Atks[0].activated == false)
        {
            Atks[0].activated = true;
            Atks[0].abilityLvl += 1;
        }
        else if (Atks[0].activated == true && Atks[0].abilityLvl <= 5)
        {
            Atks[0].abilityLvl += 1;
        }
        resume();
    }
    public void Magic()
    {
        if (Atks[1].activated == true && Atks[1].abilityLvl <= 5)
        {
            Atks[1].abilityLvl += 1;
        }
        resume();
    }
    public void MagicOrb()
    {
        if (Atks[2].activated == false)
        {
            Atks[2].activated = true;
            Atks[2].abilityLvl += 1;
        }
        else if (Atks[2].activated == true && Atks[2].abilityLvl <= 5)
        {
            Atks[2].abilityLvl += 1;
        }
        resume();
    }

    public void AddDamage()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        player.playerDamage *= 1.5f;
        resume();
    }

    private void resume()
    {
        UIManager manage = FindObjectOfType<UIManager>();
        manage.isEnabled = false;
        manage.lvlUPS.SetActive(false);
        manage.playerShooting.SetActive(true);
        Time.timeScale = 1f;
        UIManager.GameIsPaused = false;
    }
}
