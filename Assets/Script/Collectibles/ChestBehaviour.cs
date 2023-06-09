using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : Collectibles
{

    PlayerController player;
    UIManager UI;

    public static event Action OnPlayerTrigger;
    public override void add()
    {
        throw new System.NotImplementedException();
    }

    public override void Invisible()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out player))
        {
            OnPlayerTrigger.Invoke();
            Destroy(gameObject);
        }
    }
}
