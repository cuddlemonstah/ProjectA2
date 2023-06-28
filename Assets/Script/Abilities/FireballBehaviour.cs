using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public AttackStats atk;

    //!Enemy cache
    public GameObject enemy;
    private PlayerController playercon;
    private int randomEnemy = 0;
    AbilityBehaviourInLvl proj;

    // Start is called before the first frame update
    void Start()
    {
        proj = FindObjectOfType<AbilityBehaviourInLvl>();
        playercon = FindObjectOfType<PlayerController>();

        enemy = GameObject.FindGameObjectWithTag("Enemy");
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = proj.enemy[Random.Range(0, proj.enemy.Length)].transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * atk.force;

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //!Player Projectile to enemy

        float newDamage = atk.skillDamage + playercon.playerDamage;
        float damage = newDamage;
        if (atk.explodes == true)
        {
            var hitEnemies = Physics2D.OverlapCircleAll(transform.position, atk.splashRange);
            foreach (var enemies in hitEnemies)
            {
                var enemy = enemies.GetComponent<EnemyBehaviour>();
                if (enemy)
                {
                    var closestPoint = enemies.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);

                    var damagePercent = Mathf.InverseLerp(atk.splashRange, 0, distance);
                    enemy.damageDealer(damagePercent * damage);
                    Debug.Log(enemy);
                }

            }
        }
        else
        {
            //!Enemy Damage Dealer
            var e = GetComponent<EnemyBehaviour>();
            e.damageDealer(damage);
        }
        //!It randomizes the projectile target between enemies
        randomEnemy = Random.Range(0, proj.enemy.Length);


        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, atk.splashRange);
    }
}
