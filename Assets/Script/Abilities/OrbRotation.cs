using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbRotation : MonoBehaviour
{
    public AttackStats attack;
    private PlayerController playercon;
    Vector3 currentEulerAngles;
    private GameObject pivot;

    // Start is called before the first frame update
    void Start()
    {
        playercon = FindObjectOfType<PlayerController>();
        pivot = GameObject.FindGameObjectWithTag("Rotational Pivot");
    }

    // Update is called once per frame
    void Update()
    {
        currentEulerAngles += new Vector3(0, 0, 1) * Time.deltaTime * attack.rotationalSpeed;
        pivot.transform.localEulerAngles = currentEulerAngles;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //!Player Projectile to enemy
        if (other.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy))
        {
            float newDamage = attack.skillDamage + playercon.playerDamage;
            float damage = newDamage;
            enemy.damageDealer(damage);
        }
    }
}
