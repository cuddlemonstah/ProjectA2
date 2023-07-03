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
        playerStats[0].text.text = "Level " + player.playerCurrentLvl + " / " + player.playerMaxLvl;
    }
}
