using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbRotation : MonoBehaviour
{
    public AttackStats attack;
    public GameObject pivot;
    private PlayerController playercon;

    // Start is called before the first frame update
    void Start()
    {
        playercon = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivot.transform.position, new Vector3(0, 0, 1), attack.rotationalSpeed + Time.deltaTime);
        Mathf.Clamp(this.transform.position.x, -2f, 2f);
        Mathf.Clamp(this.transform.position.y, -2f, 2f);
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
