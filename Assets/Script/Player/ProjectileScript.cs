using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    //!Player cache
    private Vector3 mousePos;
    Vector3 direction;
    private Camera mainCam;
    private Rigidbody2D rb;
    public AttackStats Default;
    AbilityBehaviour proj;

    //!Enemy cache
    private GameObject player;
    private PlayerController playercon;
    //!Bullet Behaviour
    public static bool ricochet;
    float collisionCount;

    // Start is called before the first frame update
    void Start()
    {
        ricochet = true;
        playercon = FindObjectOfType<PlayerController>();
        proj = FindObjectOfType<AbilityBehaviour>();
        float force = Default.force;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); //!camera
        rb = GetComponent<Rigidbody2D>();//!rigidbody

        //!All applies to the player only(shoot on mouse position)
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        //!Applies to both of them
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    }

    void Update()
    {


    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //!Player Projectile to enemy
        if (other.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy) && ricochet == false)
        {
            DamageDeal(enemy);
            Destroy(this.gameObject);
        }
        else if (enemy && ricochet == true)
        {
            direction = proj.enemy[GenerateRandom(proj.enemy.Length)].transform.position - this.transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * Default.force;
            collisionCount += 1;
            DamageDeal(enemy);
            if (collisionCount == 3)
            {
                Destroy(this.gameObject);
                collisionCount = 0;
            }

            //Debug.Log(other.collider.);
        }
    }
    void DamageDeal(EnemyBehaviour enemy)
    {
        float newDamage = Default.skillDamage + playercon.playerDamage;
        float damage = newDamage;
        enemy.damageDealer(damage);
    }

    int GenerateRandom(int i)
    {
        int currentValue = Random.Range(0, i);
        int nextValue = 0;

        //Debug.Log(currentValue);
        return currentValue;
    }

}
