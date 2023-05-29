using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    //!Player cache
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public AttackStats atkstats;

    //!Enemy cache
    private GameObject player;
    private PlayerController playercon;

    // Start is called before the first frame update
    void Start()
    {
        playercon = FindObjectOfType<PlayerController>();
        float force = atkstats.force;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); //!camera
        rb = GetComponent<Rigidbody2D>();//!rigidbody

        //!All applies to the player only(shoot on mouse position)
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        //!Applies to both of them
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //!Player Projectile to enemy
        if (other.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy))
        {
            float newDamage = atkstats.skillDamage + playercon.playerDamage;
            float damage = newDamage;
            enemy.damageDealer(damage);
            Destroy(this.gameObject);
        }
    }
}
