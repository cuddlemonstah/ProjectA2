using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{

    [SerializeField] private ParticleSystem explosion;
    public static event Action OnPlayerShield;
    public static event Action DisablePlayerShield;

    [SerializeField] private AttackStats atk;
    [SerializeField] private Transform player;
    private float health;
    private float maxHealth;
    private ShieldBar shield;

    // Start is called before the first frame update
    void Start()
    {
        shield = FindObjectOfType<ShieldBar>();
        health = atk.skillHealth;
        maxHealth = health;
        if (shield != null)
        {
            StartCoroutine(EnableGameObject(atk.TimeBeforeItsGone));
            UI(maxHealth);
        }
    }

    IEnumerator EnableGameObject(float seconds)
    {
        OnPlayerShield?.Invoke();
        yield return new WaitForSeconds(seconds);
        DisablePlayerShield?.Invoke();
        if (explosion != null)
            explosion.Play();
        shieldDestroyed();
        // Stop the particle system if needed
        if (explosion != null)
            explosion.Stop();
    }

    private void UI(float maxHealth)
    {
        shield.setMaxHP(maxHealth);
        shield.setHP(maxHealth);

    }

    public void shieldHealth(float damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0f); // Ensure health doesn't go below zero

        // Update the UI with the new health value
        shield.setHP(health);
        if (health <= 0)
        {
            shieldDestroyed();
        }
    }
    private void shieldDestroyed()
    {
        if (atk.explodes)
        {
            if (explosion != null)
                explosion.Play();
            Destroy(transform.GetChild(0).gameObject);
            var hitEnemies = Physics2D.OverlapCircleAll(transform.position, atk.splashRadius);
            foreach (var enemies in hitEnemies)
            {
                var enemy = enemies.GetComponent<EnemyBehaviour>();
                var enemyProjectile = enemies.GetComponent<EProjScript>();
                if (enemy)
                {
                    enemy.damageDealer(atk.splashDamage);
                    Destroy(enemyProjectile);
                    break;
                }
            }
            Destroy(this.gameObject, 0.5f);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}