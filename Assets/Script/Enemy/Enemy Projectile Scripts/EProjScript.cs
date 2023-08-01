using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EProjScript : MonoBehaviour
{

    private Rigidbody2D rb;

    //!Enemy cache
    private GameObject player;

    //!attributes?
    public float force = 5f;
    public float damage;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        //!Enemy Projectile to player
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.damageDealer(damage);
            Destroy(gameObject);
        }
        else if (other.collider.transform.parent.TryGetComponent<ShieldBehaviour>(out ShieldBehaviour shield))
        {
            damage *= 3f;
            shield.shieldHealth(damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }

}
