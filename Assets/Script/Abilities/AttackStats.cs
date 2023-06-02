using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttacksScriptableObject", menuName = "ScriptableObjects/PlayerAttack")]
public class AttackStats : ScriptableObject
{
    public string attackName;
    public float skillDamage;
    public float force;
    public float rotationalSpeed;
    public Animation Anim;
    public float timeBetweenFiring;
    public GameObject bullet;
    public int abilityLvl;
    public bool activated;
}
