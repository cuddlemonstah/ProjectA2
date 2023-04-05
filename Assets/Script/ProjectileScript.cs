using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    //!Player cache
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;

    //!Enemy cache
    private GameObject player;

    //!attributes?
    public float force;
    public float damage = 20f;


    // Start is called before the first frame update
    void Start()
    {
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
            enemy.damageDealer(damage);
            Destroy(gameObject);
        }
    }
}
