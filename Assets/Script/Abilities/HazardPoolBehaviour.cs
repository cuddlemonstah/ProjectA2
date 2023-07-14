using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardPoolBehaviour : MonoBehaviour
{
    [SerializeField]
    private AttackStats atk;
    private CrowdControl CC;
    private EnemyBehaviour enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<EnemyBehaviour>();
        Destroy(gameObject, atk.TimeBeforeItsGone);
        this.transform.localScale = new Vector3(atk.splashRadius, atk.splashRadius, 1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemyEnter))
        {
            InvokeRepeating("Tick", 0f, 0.3f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemyExit))
        {
            CancelInvoke("Tick");
        }
    }
    void Tick()
    {
        enemy.damageDealer(atk.skillDamage);
    }
}
