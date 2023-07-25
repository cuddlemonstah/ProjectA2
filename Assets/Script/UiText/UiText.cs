using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiText : MonoBehaviour
{

    [SerializeField]
    private PlayerController player;
    public UITextArray[] playerStats;

    // Update is called once per frame
    void Update()
    {
        playerStats[0].text.text = "Level " + player.playerCurrentLvl + " / " + player.playerMaxLvl; // level
        //playerStats[1].text.text = ": " + player.health + " / " + player.maxHP; // health
        //playerStats[2].text.text = ": " + player.mana + " / " + player.maxMana; // mana
        playerStats[3].text.text = ": " + player.healthRegen; // health regen
        playerStats[4].text.text = ": " + player.manaRegen; // mana regen
        playerStats[5].text.text = ": " + player.playerDamage; // damage
        playerStats[6].text.text = ": " + player.playerCoolDown; // cooldown
        playerStats[7].text.text = ": " + player.playerCurrentXp + " / " + player.playerMaxXp; // Xp
    }
}
