using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //!cache
    Rigidbody2D rigid;
    HealthBar HP;
    ManaBar Mana;
    public static event Action OnPlayerDeath;

    //!adjustments
    float vertical;
    float horizontal;
    [SerializeField] float speed = 5f;
    public float health, maxHP = 10f;
    public float mana, maxMana = 100f;
    public bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHP;
        mana = maxMana;
        HP = FindObjectOfType<HealthBar>();
        Mana = FindObjectOfType<ManaBar>();
        rigid = GetComponent<Rigidbody2D>();
        HP.setMaxHP(maxHP);
        HP.setHP(maxHP);
        Mana.setMaxMana(maxMana);
        Mana.setMana(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerWalk();
    }

    void PlayerWalk()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        Vector2 move = new Vector2(vertical, horizontal);
        rigid.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    public void Health(float amount)
    {
        if (isInvincible) return;
        health = Mathf.Clamp(health + amount, 0, maxHP);
        if (health <= 0)
        {
            health = 0;
            return;
        }
        HP.setHP(health);
        StartCoroutine(BecomeTemporarilyInvincible());
    }

    public IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        isInvincible = true;
        yield return new WaitForSeconds(1);
        isInvincible = false;
        Debug.Log("invincible! turned off");

    }
    public void damageDealer(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            
            OnPlayerDeath?.Invoke();
        }
        HP.setHP(health);
    }
}
