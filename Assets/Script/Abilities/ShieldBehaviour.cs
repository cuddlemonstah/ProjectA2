using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{

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
            UI();
            Debug.Log(maxHealth);
        }
    }

    IEnumerator EnableGameObject(float seconds)
    {
        OnPlayerShield?.Invoke();
        yield return new WaitForSeconds(20);
        DisablePlayerShield?.Invoke();
        Destroy(this.gameObject);
    }

    private void UI()
    {
        shield.setHP(maxHealth);
        shield.setMaxHP(maxHealth);

    }

    public void shieldHealth(float damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0f); // Ensure health doesn't go below zero

        // Update the UI with the new health value
        shield.setHP(health);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}