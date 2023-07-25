using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    [SerializeField] private AttackStats atk;
    [SerializeField] private Transform player;
    private float health;
    private float maxHealth;
    [SerializeField] private GameObject UI;
    private ShieldBar shield;

    // Start is called before the first frame update
    void Start()
    {
        shield = FindObjectOfType<ShieldBar>();
        health = atk.skillHealth;
        maxHealth = health;
        StartCoroutine(EnableGameObject());
    }

    IEnumerator EnableGameObject()
    {
        if (!UI.activeInHierarchy)
            UI.SetActive(true);

        yield return new WaitForSeconds(atk.TimeBeforeItsGone);
        UI.SetActive(false);
        Destroy(this.gameObject);
    }

    public void shieldHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}