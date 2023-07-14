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
    float[] Xp;

    void Start()
    {
        int arraySize = enemies.Length;
        speed = new float[arraySize];
        damage = new float[arraySize];
        health = new float[arraySize];
        Xp = new float[arraySize];
        for (int i = 0; i < enemies.Length; i++)
        {
            GetStatXp(i, enemies[i].giveXp);
            GetStatSpeed(i, enemies[i].speed);
            GetStatDamage(i, enemies[i].damage);
            GetStatHealth(i, enemies[i].health);
        }
    }
    private void GetStatSpeed(int index, float speed)
    {
        this.speed[index] = speed;
    }
    private void GetStatDamage(int index, float damage)
    {
        this.damage[index] = damage;
    }
    private void GetStatHealth(int index, float health)
    {
        this.health[index] = health;
    }
    private void GetStatXp(int index, float Xp)
    {
        this.Xp[index] = Xp;
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
    public float setXp(int idNo)
    {
        return Xp[idNo];
    }

}
