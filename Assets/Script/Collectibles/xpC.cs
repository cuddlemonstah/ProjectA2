using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpC : Collectibles
{
    PlayerController player;
    public override void add()
    {
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
            add();
            Destroy(gameObject);
        }
    }
}
