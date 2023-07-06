using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBehaviour : MonoBehaviour
{

    public AttackStats atk;
    private PlayerController player;

    public static bool stuns = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        var thisObj = GetComponent<CircleCollider2D>();
        //thisObj.radius = atk.splashRange;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        float newDamage = atk.skillDamage + player.playerDamage;
        float damage = newDamage;
        if (other.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enem) || other.CompareTag("Ground") && atk.explodes == true)
        {
            Debug.Log(other);
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
        else if (other.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy) && atk.explodes == false)
        {
            //!Enemy Damage Dealer
            enemy.damageDealer(damage);
        }
        Destroy(this.gameObject, 0.2f);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, atk.splashRange);
    }
    void stunBeh()
    {
        
    }

}
