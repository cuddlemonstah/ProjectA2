using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    [SerializeField]
    private AttackStats atk;
    [SerializeField]
    private Transform player;
    float health;
    float damageMultiplier = 3f;
    // Start is called before the first frame update
    void Start()
    {
        health = atk.skillHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void shieldHealth(float damage)
    {
        health -= damage * damageMultiplier;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
