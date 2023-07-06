using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    //!cache
    HealthBar HP;

    Transform target;

    [SerializeField]
    public EnemyScriptObj enemies;

    void Awake()
    {
        target = GameObject.Find("Player").transform;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (Vector2.Distance(transform.position, target.position) > enemies.infiniteDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, enemies.speed * Time.deltaTime);
        }
    }
    public void damageDealer(float damage)
    {
        enemies.health -= damage;
        if (enemies.health <= 0f)
        {
            Destroy(gameObject);
            FindObjectOfType<PlayerController>().experienceAdd(enemies.giveXp);
            for (int i = 1; i < FindObjectOfType<PlayerController>().playerCurrentLvl; i++)
            {
                enemies.giveXp *= 1.2f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.damageDealer(enemies.damage);
            player.experienceAdd(enemies.giveXp);
            Destroy(gameObject);
        }
    }
}
