using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReset : MonoBehaviour
{
    public ER[] enemies;

    float speed;
    float damage;
    float health;

    void GetStat(float speed, float damage, float health)
    {
        this.speed = speed;
        this.damage = damage;
        this.health = health;
    }

    
}
