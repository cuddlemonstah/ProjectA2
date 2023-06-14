using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedAbilities : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public AttackStats atk;

    //!Enemy cache
    public GameObject enemy;
    private PlayerController playercon;
    private int randomEnemy = 0;
    AbilityBehaviour proj;

    // Start is called before the first frame update
    void Start()
    {
        proj = FindObjectOfType<AbilityBehaviour>();
        playercon = FindObjectOfType<PlayerController>();

        enemy = GameObject.FindGameObjectWithTag("Enemy");
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = proj.enemy[Random.Range(0, proj.enemy.Length)].transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * atk.force;

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        //!Player Projectile to enemy
        if (other.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy))
        {
            //!Enemy Damage Dealer
            float newDamage = atk.skillDamage + playercon.playerDamage;
            float damage = newDamage;
            enemy.damageDealer(damage);

            //!It randomizes the projectile target between enemies
            randomEnemy = Random.Range(0, proj.enemy.Length);
            Destroy(this.gameObject);
        }
    }
}
