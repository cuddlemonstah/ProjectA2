using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    //!cache
    HealthBar HP;

    //!attributes
    [SerializeField] float speed = 5f;

    Transform target;
    float infiniteDistance = 0f;
    public float damage;
    public float health;
    public float giveXp = 0.5f;
    public bool Exist;

    void Awake()
    {
        target = GameObject.Find("Player").transform;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (Vector2.Distance(transform.position, target.position) > infiniteDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
    public void damageDealer(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Destroy(gameObject);
            FindObjectOfType<PlayerController>().experienceAdd(giveXp);
            for (int i = 1; i < FindObjectOfType<PlayerController>().playerCurrentLvl; i++)
            {
                giveXp *= 1.2f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.damageDealer(damage);
            player.experienceAdd(giveXp);
            Destroy(gameObject);
        }
    }

    void OnBecameVisible()
    {
        Exist = true;
    }

    void OnBecameInvisible()
    {
        Exist = false;
    }

}
