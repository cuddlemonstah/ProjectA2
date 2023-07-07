using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReset : MonoBehaviour
{
    [SerializeField]
    EnemyScriptObj[] enemies;

    public float speed;
    float damage;
    float health;

    void GetStat(float speed, float damage, float health)
    {
        this.speed = speed;
        this.damage = damage;
        this.health = health;
    }

    void Update()
    {

        //! Get Melee Stat
        GetStat(enemies[0].speed, enemies[0].damage, enemies[0].health);
        //! Get Range Stat
        GetStat(enemies[1].speed, enemies[1].damage, enemies[1].health);

    }

}
