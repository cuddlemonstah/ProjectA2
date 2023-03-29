using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //!cache
    Rigidbody2D rigid;
    public SpriteRenderer sprite;
    HealthBar HP;
    ManaBar Mana;
    public static event Action OnPlayerDeath;

    //!Player stats
    public float health, maxHP = 10f;
    public float mana, maxMana = 100f;
    public float playerMaxXp = 50f;
    public float playerCurrentXp;
    public int playerCurrentLvl;
    public int playerMaxLvl = 50;
    //!adjustments
    float vertical;
    float horizontal;
    [SerializeField] float speed = 5f;
    public bool isInvisible = false;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentLvl = 1;
        health = maxHP;
        mana = maxMana;
        HP = FindObjectOfType<HealthBar>();
        Mana = FindObjectOfType<ManaBar>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
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
        health = Mathf.Clamp(health + amount, 0, maxHP);
        if (health <= 0)
        {
            health = 0;
            return;
        }
        HP.setHP(health);
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

    public IEnumerator BecomeTemporarilyInvincible()
    {
        Color Invicolor1;
        Color OGcolor2;

        ColorUtility.TryParseHtmlString("#92C5D2", out Invicolor1);
        ColorUtility.TryParseHtmlString("#A3D6AD", out OGcolor2);

        GetComponent<Collider2D>().enabled = false;
        sprite.color = Invicolor1;
        yield return new WaitForSeconds(InviC.FindObjectOfType<InviC>().setInviTime());
        GetComponent<Collider2D>().enabled = true;
        sprite.color = OGcolor2;

    }

    public void experienceAdd(float Xp)
    {
        playerCurrentXp += Xp;
        Debug.Log(playerCurrentXp + "/" + playerMaxXp);
    }

}
