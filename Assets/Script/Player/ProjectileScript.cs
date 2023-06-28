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
    Collision2D other;
    static AbilityBehaviourInLvl proj;

    //!Enemy cache
    private GameObject player;
    private PlayerController playercon;
    private static List<GameObject> enemyRange = new List<GameObject>();
    //!Bullet Behaviour
    public static bool ricochet;
    public int collisionCount;
    public static int collisionCountMax;
    private static int currentValue;
    private static int nextValue;

    // Start is called before the first frame update
    void Start()
    {
        //!Ability behaviour
        ricochet = false;
        collisionCountMax = 3;

        //!Cache
        playercon = FindObjectOfType<PlayerController>();
        proj = FindObjectOfType<AbilityBehaviourInLvl>();
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

        GenerateRandom();
    }

    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        currentValue = enemyRange.IndexOf(other.gameObject);
        //!Player Projectile to enemy
        if (other.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy) && ricochet == false)
        {
            DamageDeal(enemy);
            Destroy(this.gameObject);
        }
        else if (enemy && ricochet == true)
        {
            direction = proj.enemy[GenerateRandom()].transform.position - this.transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * Default.force;
            collisionCount += 1;
            DamageDeal(enemy);
            if (collisionCount == collisionCountMax)
            {
                Destroy(this.gameObject);
                collisionCount = 0;
            }
        }
    }
    void DamageDeal(EnemyBehaviour enemy)
    {
        float newDamage = Default.skillDamage + playercon.playerDamage;
        float damage = newDamage;
        enemy.damageDealer(damage);
    }

    static int GenerateRandom()
    {
        nextValue = Random.Range(0, proj.enemy.Length);
        enemyRange.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        if (nextValue == currentValue)
        {
            nextValue = Random.Range(0, proj.enemy.Length);
            return nextValue;
        }
        return nextValue;
    }

}
