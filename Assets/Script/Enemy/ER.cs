using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ER
{
    public string enemName;
    [SerializeField]
    EnemyScriptObj EnemyTypes;
    [SerializeField]
    float speed;
    [SerializeField]
    float damage;
    [SerializeField]
    float health;

}
