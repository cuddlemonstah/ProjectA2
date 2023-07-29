using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHazardProj : MonoBehaviour
{

    private PlayerController player;
    private ShieldBehaviour shield;
    private float percentageDamage = 0.03f;
    private float newDamage;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        shield = FindObjectOfType<ShieldBehaviour>();
        Destroy(this.gameObject, 3f);
    }

    void Update()
    {
        newDamage = Mathf.Abs(player.health * percentageDamage);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            InvokeRepeating("TickPlayer", 0f, 0.2f);
        }
        else if (other.gameObject.TryGetComponent<ShieldBehaviour>(out ShieldBehaviour shield))
        {
            InvokeRepeating("TickShield", 0f, 0.2f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            CancelInvoke();
        }
        else if (other.gameObject.TryGetComponent<ShieldBehaviour>(out ShieldBehaviour shield))
        {
            CancelInvoke();
        }
    }
    private void TickPlayer()
    {
        player.damageDealer(newDamage);
    }

    private void TickShield()
    {
        shield.shieldHealth(newDamage);
    }
}
