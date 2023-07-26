using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBehaviour : MonoBehaviour
{

    [SerializeField] private AttackStats atk;
    private CrowdControl CC;
    private PlayerController player;
    private EnemyBehaviour enemy;


    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<EnemyBehaviour>();
        player = FindObjectOfType<PlayerController>();
        Destroy(this.gameObject, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        var thisObj = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        float newDamage = atk.skillDamage + player.playerDamage;
        float damage = newDamage;
        if (other.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enem)
        || other.CompareTag("Ground")
        && atk.explodes == true)
        {
            var hitEnemies = Physics2D.OverlapCircleAll(transform.position, atk.splashRadius);
            foreach (var enemies in hitEnemies)
            {
                var enemy = enemies.GetComponent<EnemyBehaviour>();
                if (enemy)
                {
                    var closestPoint = enemies.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);

                    var damagePercent = Mathf.InverseLerp(atk.splashRadius, 0, distance);
                    enemy.damageDealer(damagePercent * damage);
                }

            }
        }
        if (other.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy1)
        || other.CompareTag("Ground")
        && atk.stuns == true && atk.explodes == true)
        {
            var hitEnemies = Physics2D.OverlapCircleAll(transform.position, atk.splashRadius);
            foreach (var enemies in hitEnemies)
            {
                var enemy = enemies.GetComponent<EnemyBehaviour>();
                if (enemy)
                {
                    if (enemy.TryGetComponent<ICCable>(out ICCable cc))
                    {
                        cc.applyStun(CC.stunDuration);
                    }
                    var closestPoint = enemies.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);
                    var damagePercent = Mathf.InverseLerp(atk.splashRadius, 0, distance);
                    enemy.damageDealer(damagePercent * damage);
                }

            }
        }
        else if (other.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy))
        {
            //!Enemy Damage Dealer
            enemy.damageDealer(damage);
        }
    }
}
