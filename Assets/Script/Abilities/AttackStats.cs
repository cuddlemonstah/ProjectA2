using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttacksScriptableObject", menuName = "ScriptableObjects/PlayerAttack")]
public class AttackStats : ScriptableObject
{
    public string attackName;
    public float skillDamage;
    public float splashDamage;
    public float force;
    public float rotationalSpeed;
    public float splashRange;
    public float timeBetweenFiring;
    public Animation Anim;
    public GameObject bullet;
    public int abilityLvl;
    public bool explodes;
    public bool activated;
}
