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
        else if (Atks[0].activated == true && Atks[0].abilityLvl < 5)
        {
            Atks[0].abilityLvl += 1;
        }
        if (Atks[0].abilityLvl == 2)
        {
            Atks[0].skillDamage += 15;
        }
        if (Atks[0].abilityLvl == 5)
        {
            Atks[0].skillDamage += 15;
        }
        resume();
    }
    public void Magic()
    {
        if (Atks[1].activated == true && Atks[1].abilityLvl < 5)
        {
            Atks[1].abilityLvl += 1;
        }
        if (Atks[1].abilityLvl == 4)
        {
            Atks[1].skillDamage += 10;
        }
        if (Atks[1].abilityLvl == 5)
        {
            Atks[1].skillDamage += 5;
            Atks[1].timeBetweenFiring -= 0.3f;
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
        else if (Atks[2].activated == true && Atks[2].abilityLvl < 5)
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

    public void Lightning()
    {

        if (Atks[3].activated == false)
        {
            Atks[3].activated = true;
            Atks[3].abilityLvl += 1;
        }
        else if (Atks[3].activated == true && Atks[3].abilityLvl < 5)
        {
            Atks[3].abilityLvl += 1;
        }
        if (Atks[3].abilityLvl == 3)
        {
            Atks[3].skillDamage += 30;
            Atks[3].timeBetweenFiring = 1.75f;
            Atks[3].splashRadius = 1f;
        }
        if (Atks[3].abilityLvl == 4)
        {
            Atks[3].stuns = true;
            Atks[3].skillDamage += 20;
            Atks[3].timeBetweenFiring = 1.65f;
            Atks[3].splashRadius = 1.25f;
        }
        if (Atks[3].abilityLvl == 5)
        {
            Atks[3].stuns = true;
            Atks[3].skillDamage += 10;
            Atks[3].splashRadius = 2;
        }
        resume();
    }

    public void HazPool()
    {
        if (Atks[4].activated == false)
        {
            Atks[4].activated = true;
            Atks[4].abilityLvl += 1;
        }
        else if (Atks[4].activated == true && Atks[0].abilityLvl < 5)
        {
            Atks[4].abilityLvl += 1;
        }
        if (Atks[4].abilityLvl == 2)
        {
            Atks[4].skillDamage = 6.5f;
            Atks[4].TimeBeforeItsGone = 5f;
        }
        if (Atks[4].abilityLvl == 3)
        {
            Atks[4].splashRadius = 1f;
            Atks[4].timeBetweenFiring = 16f;
        }
        if (Atks[4].abilityLvl == 4)
        {
            Atks[4].skillDamage = 7f;
            Atks[4].TimeBeforeItsGone = 6f;
        }
        if (Atks[4].abilityLvl == 5)
        {
            Atks[4].splashRadius = 1.3f;
            Atks[4].skillDamage = 10f;
            Atks[4].TimeBeforeItsGone = 7f;
            Atks[4].timeBetweenFiring = 14f;
        }
        resume();
    }
    public void Shield()
    {
        if (Atks[5].activated == false)
        {
            Atks[5].activated = true;
            Atks[5].abilityLvl += 1;
        }
        else if (Atks[5].activated == true && Atks[0].abilityLvl < 5)
        {
            Atks[5].abilityLvl += 1;
        }
        if (Atks[5].abilityLvl == 2)
        {
            Atks[5].TimeBeforeItsGone = 6f;
        }
        if (Atks[4].abilityLvl == 3)
        {
            Atks[5].timeBetweenFiring = 20f;
            Atks[5].TimeBeforeItsGone = 6.7f;
        }
        if (Atks[4].abilityLvl == 4)
        {
            Atks[5].timeBetweenFiring = 19f;
            Atks[5].TimeBeforeItsGone = 7.5f;
        }
        if (Atks[5].abilityLvl == 5)
        {
            Atks[5].timeBetweenFiring = 18f;
            Atks[5].TimeBeforeItsGone = 8f;
            Atks[5].explodes = true;
        }
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
