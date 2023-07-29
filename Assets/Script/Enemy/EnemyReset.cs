using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReset : MonoBehaviour
{
    [SerializeField]
    EnemyScriptObj[] enemies;

    private float[] speed;
    private float[] damage;
    private float[] health;
    private float[] Xp;
    private float[] damageMultiplier;
    private bool[] follows;
    private bool[] explodes;

    void Start()
    {
        int arraySize = enemies.Length;
        speed = new float[arraySize];
        damage = new float[arraySize];
        health = new float[arraySize];
        Xp = new float[arraySize];
        damageMultiplier = new float[arraySize];
        follows = new bool[arraySize];
        explodes = new bool[arraySize];
        for (int i = 0; i < enemies.Length; i++)
        {
            GetStatXp(i, enemies[i].giveXp);
            GetStatSpeed(i, enemies[i].speed);
            GetStatDamage(i, enemies[i].damage);
            GetStatHealth(i, enemies[i].health);
            GetStatDamageMultiplier(i, enemies[i].damageMultiplier);
            GetBoolFollows(i, enemies[i].follows);
            GetBoolExplodes(i, enemies[i].explodes);
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
    private void GetStatDamageMultiplier(int index, float damageMultiplier)
    {
        this.damageMultiplier[index] = damageMultiplier;
    }
    private void GetBoolFollows(int index, bool follows)
    {
        this.follows[index] = follows;
    }
    private void GetBoolExplodes(int index, bool explodes)
    {
        this.explodes[index] = explodes;
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
    public float setDamageMultiplier(int idNo)
    {
        return damageMultiplier[idNo];
    }

    public bool setBoolFollows(int idNo)
    {
        return follows[idNo];
    }
    public bool setBoolExplodes(int idNo)
    {
        return explodes[idNo];
    }

}
