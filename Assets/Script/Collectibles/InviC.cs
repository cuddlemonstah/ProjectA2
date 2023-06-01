using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InviC : Collectibles
{

    PlayerController player;
    public override void add()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out player))
        {
            Invisible();
            func.currentInvi--;
            Destroy(gameObject);
        }
    }

    public override void Invisible()
    {
        player.StartCoroutine(player.BecomeTemporarilyInvincible());
    }

    public float setInviTime()
    {
        return invisibleTime;
    }
}
