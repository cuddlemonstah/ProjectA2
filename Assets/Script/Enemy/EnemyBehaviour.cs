using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    //!Cache
    Rigidbody2D rigid;
    HealthBar HP;
    Transform target;

    [SerializeField] EnemyScriptObj enemies;
    public EnemyReset ER;

    float vertical, horizontal;
    public float speed, health;
    private bool stunned = false;
    public int idNo;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        ER = FindObjectOfType<EnemyReset>();
        idNo = enemies.idNo;
        Invoke("set", 0.2f);
        //!real
        target = GameObject.Find("Player").transform;
    }
    void set()
    {
        speed = ER.setSpeed(idNo);
        health = ER.setHealth(idNo);
    }

    void FixedUpdate()
    {
        //!!TESTTTTT
        // vertical = Input.GetAxisRaw("Vertical");
        // horizontal = Input.GetAxisRaw("Horizontal");

        // Vector2 move = new Vector2(vertical, horizontal);
        // rigid.velocity = new Vector2(horizontal * speed, vertical * speed);

        //!REALL
        if (Vector2.Distance(transform.position, target.position) > enemies.infiniteDistance)
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
            var playerController = FindObjectOfType<PlayerController>();
            playerController.experienceAdd(enemies.giveXp);

            for (int i = 1; i < playerController.playerCurrentLvl; i++)
            {
                enemies.giveXp *= 1.2f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.damageDealer(ER.setDamage(idNo));
            player.experienceAdd(enemies.giveXp);
            Destroy(gameObject);
        }
    }


    public void ApplyStun(float duration)
    {
        if (!stunned)
        {
            StartCoroutine(StunCoroutine(duration));
        }
    }

    private IEnumerator StunCoroutine(float duration)
    {
        stunned = true;
        speed = 0f;
        yield return new WaitForSeconds(duration);
        speed = ER.setSpeed(idNo);
        stunned = false;
    }


}
