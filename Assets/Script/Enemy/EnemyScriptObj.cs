using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptObj", menuName = "ScriptableObjects/Enemies")]
public class EnemyScriptObj : ScriptableObject
{
    public int idNo;
    public float speed;
    public float infiniteDistance = 0f;
    public float damage;
    public float health;
    public float giveXp;

}
