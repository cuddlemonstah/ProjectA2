using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] float speed = 5f;

    Transform target;
    float infiniteDistance = 0f;
    public float damage;
    public float health;


    void Awake()
    {
        target = GameObject.Find("Player").transform;
    }
    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (Vector2.Distance(transform.position, target.position) > infiniteDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
    public void damageDealer(float damage)
    {
        health -= damage;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided With: " + other);
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.damageDealer(damage);
            Destroy(gameObject);
        }
    }

}
