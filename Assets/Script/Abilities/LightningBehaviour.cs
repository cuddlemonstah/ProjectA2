using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBehaviour : MonoBehaviour
{

    public AttackStats atk;
    private PlayerController player;

    public float splashRange;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        float newDamage = atk.skillDamage + player.playerDamage;
        float damage = newDamage;
        if (other.gameObject.CompareTag("Ground") && atk.explodes == true)
        {
            var hitGround = Physics2D.OverlapCircleAll(transform.position, splashRange);
            foreach (var enemies in hitGround)
            {
                var enemy = enemies.GetComponent<EnemyBehaviour>();
                if (enemy)
                {
                    var closestPoint = enemies.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);

                    var damagePercent = Mathf.InverseLerp(atk.splashRange, 0, distance);
                    enemy.damageDealer(damage);
                    Debug.Log(enemy + " " + damagePercent);
                }

            }
        }
        else if (other.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy) && atk.explodes == false)
        {
            //!Enemy Damage Dealer
            enemy.damageDealer(damage);
        }
        Destroy(this.transform.parent.gameObject, 0.2f);
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y - 6.3f), splashRange);
    }

}
