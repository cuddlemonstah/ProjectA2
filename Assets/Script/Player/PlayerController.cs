using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //!cache
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    HealthBar HP;
    ManaBar Mana;
    XpBar XpBar;
    public static event Action OnPlayerDeath;
    public static event Action OnPlayerLevelUp;

    //!Player stats
    public float health, maxHP = 10f;
    public float mana, maxMana = 100f;
    public float healthRegen, manaRegen, playerCoolDown, playerDamage;
    public float playerCurrentXp, playerMaxXp = 30f;
    public int playerCurrentLvl, playerMaxLvl = 20;

    //!Player dash
    public float dashSpeed;
    public float dashLength = .3f, dashCooldown = 0.7f;
    private float dashCounter;
    private float dashCoolCounter;
    //!adjustments
    float vertical;
    float horizontal;
    public float speed = 5f;
    public bool isInvisible = false;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentLvl = 1;
        playerDamage = 20f;
        health = maxHP;
        mana = maxMana;
        healthRegen = 0.5f;
        manaRegen = 0.3f;
        HP = FindObjectOfType<HealthBar>();
        Mana = FindObjectOfType<ManaBar>();
        XpBar = FindObjectOfType<XpBar>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        UI();
    }

    void UI()
    {
        HP.setMaxHP(maxHP);
        HP.setHP(maxHP);
        Mana.setMaxMana(maxMana);
        Mana.setMana(maxMana);
        XpBar.setMaxXp(playerMaxXp);
        XpBar.setXp(playerCurrentXp);
        XpBar.setLvlText(playerCurrentLvl);

    }
    // Update is called once per frame
    void Update()
    {
        PlayerWalk();
        playerDash();
    }

    void PlayerWalk()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        Vector2 move = new Vector2(vertical, horizontal);
        rigid.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    void playerDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                speed = dashSpeed;
                dashCounter = dashLength;
                StartCoroutine(dashInvi());
            }

        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                speed = 5f;
                dashCoolCounter = dashCooldown;
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
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
            Destroy(this.gameObject);
        }
        HP.setHP(health);
    }

    //!Invisible
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

    //!Invisible in dashing
    public IEnumerator dashInvi()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(dashLength);
        GetComponent<Collider2D>().enabled = true;
    }
    public void experienceAdd(float Xp)
    {
        playerCurrentXp += Xp;
        for (int i = playerCurrentLvl; playerCurrentXp >= playerMaxXp; i++)
        {
            playerCurrentXp = 0f;
            playerMaxXp *= 1.7f;
            playerCurrentLvl += 1;
            OnPlayerLevelUp?.Invoke();
        }
        XpBar.setMaxXp(playerMaxXp);
        XpBar.setXp(playerCurrentXp);
        XpBar.setLvlText(playerCurrentLvl);
    }


}
