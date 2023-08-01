using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, ICCable
{
    //! Cache
    Rigidbody2D rigid;
    Transform target;
    PlayerController player;

    [SerializeField] EnemyScriptObj enemies;
    EnemyReset ER;

    //! Objects
    public GameObject ExplosionHazard;

    float vertical, horizontal;
    public float speed, health, Xp, damage, damageMultiplier;
    private bool stunned = false;
    private bool follows = false, explodes = false;
    public int idNo;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        ER = FindObjectOfType<EnemyReset>();
        idNo = enemies.idNo;
        SetStats();
        //! Real
        target = GameObject.Find("Player").transform;
        //! If the enemy does not follow
        if (!follows)
        {
            Vector3 direction = player.transform.position - transform.position;
            rigid.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        }
    }

    //! Setting the stats of the Enemy
    void SetStats()
    {
        speed = ER.setSpeed(idNo);
        health = ER.setHealth(idNo);
        Xp = ER.setXp(idNo);
        damage = ER.setDamage(idNo);
        damageMultiplier = ER.setDamageMultiplier(idNo);
        follows = ER.setBoolFollows(idNo);
        explodes = ER.setBoolExplodes(idNo);
    }

    void FixedUpdate()
    {
        //!!TESTTTTT
        // vertical = Input.GetAxisRaw("Vertical");
        // horizontal = Input.GetAxisRaw("Horizontal");

        // Vector2 move = new Vector2(vertical, horizontal);
        // rigid.velocity = new Vector2(horizontal * speed, vertical * speed);

        EnemyMovement(follows);
    }

    void EnemyMovement(bool follows)
    {
        if (follows && target != null)
        {
            if (Vector2.Distance(transform.position, target.position) > enemies.infiniteDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }

    public void damageDealer(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            if (explodes)
            {
                Instantiate(ExplosionHazard, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);

            // Calculate the total experience points and add it to the player
            player.experienceAdd(Xp);
            Xp *= Mathf.Pow(2.5f, player.playerCurrentLvl - 1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //! If collided with Player
        if (other.collider.GetComponent<PlayerController>())
        {
            if (explodes)
            {
                Instantiate(ExplosionHazard, player.transform.position, Quaternion.identity);
            }

            var playerController = other.collider.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.damageDealer(damage);
                playerController.experienceAdd(Xp);
            }
            Destroy(gameObject);
        }
        //! If collided with Shield
        else if (other.collider.transform.parent != null && other.collider.transform.parent.TryGetComponent<ShieldBehaviour>(out ShieldBehaviour shield))
        {
            if (explodes)
            {
                Instantiate(ExplosionHazard, other.transform.position, Quaternion.identity);
            }
            shield.shieldHealth(damage);
            var playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.experienceAdd(Xp);
            }
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Barrier"))
        {
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

    //? Apply Crowd Controls in Enemies
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