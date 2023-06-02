using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpC : Collectibles
{
    PlayerController player;
    public override void add()
    {
        for (int i = 1; i < player.playerCurrentLvl; i++)
        {
            XpAdd *= 1.1f;

        }
        player.experienceAdd(XpAdd);
    }

    public override void Invisible()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out player))
        {
            switch (xpName)
            {
                case "Small":
                    add();
                    func.currentSmall--;
                    Destroy(gameObject);
                    break;
                case "Medium":
                    add();
                    func.currentMedium--;
                    Destroy(gameObject);
                    break;
                case "Large":
                    add();
                    func.currentLarge--;
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
