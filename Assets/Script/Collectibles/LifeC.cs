using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeC : Collectibles
{
    //!different invisible
    PlayerController player;
    public override void Invisible()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out player))
        {
            add();
            func.currentLife--;
            Destroy(gameObject);
        }
    }
    public override void add()
    {
        if (player.health < player.maxHP)
        {
            player.Health(healthAdd);
        }
    }
}
