using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour, ICCable
{
    //!Cache
    Rigidbody2D rigid;
    HealthBar HP;
    Transform target;
    PlayerController player;

    [SerializeField] EnemyScriptObj enemies;
    public EnemyReset ER;

    float vertical, horizontal;
    public float speed, health, Xp, damage, damageMultiplier;
    private bool stunned = false;
    public int idNo;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
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
        Xp = ER.setXp(idNo);
        damage = ER.setDamage(idNo);
        damageMultiplier = ER.setDamageMultiplier(idNo);
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
            playerController.experienceAdd(Xp);
            for (int i = 1; i < playerController.playerCurrentLvl; i++)
            {
                Xp *= 1.2f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController players))
        {
            players.damageDealer(damage);
            players.experienceAdd(Xp);
            Destroy(gameObject);
        }
        else if (other.gameObject.TryGetComponent<ShieldBehaviour>(out ShieldBehaviour shield))
        {
            damage *= damageMultiplier;
            shield.shieldHealth(damage);
            player.experienceAdd(Xp);
            Destroy(gameObject);
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

    public void applyStun(float duration)
    {
        if (!stunned)
        {
            StartCoroutine(StunCoroutine(duration));
        }
    }

    public void applySlow(float duration)
    {
        throw new System.NotImplementedException();
    }

    public void applyPoison(float duration)
    {
        throw new System.NotImplementedException();
    }
}
