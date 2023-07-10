using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReset : MonoBehaviour
{
    [SerializeField]
    EnemyScriptObj[] enemies;

    float[] speed;
    float[] damage;
    float[] health;

    void Start()
    {
        int arraySize = enemies.Length;
        speed = new float[arraySize];
        damage = new float[arraySize];
        health = new float[arraySize];
        for (int i = 0; i < enemies.Length; i++)
        {
            GetStatSpeed(i, enemies[i].speed);
            GetStatDamage(i, enemies[i].damage);
            GetStatHealth(i, enemies[i].health);
        }
    }
    public void GetStatSpeed(int index, float speed)
    {
        this.speed[index] = speed;
    }
    public void GetStatDamage(int index, float damage)
    {
        this.damage[index] = damage;
    }
    public void GetStatHealth(int index, float health)
    {
        this.health[index] = health;
    }

    public float setSpeed(int idNo)
    {
        return speed[idNo];
    }
    public float setDamage(int idNo)
    {
        return damage[idNo];
    }
    public float setHealth(int idNo)
    {
        return health[idNo];
    }

}
