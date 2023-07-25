using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttacksScriptableObject", menuName = "ScriptableObjects/PlayerAttack")]
public class AttackStats : ScriptableObject
{
    public string attackName;
    public float skillHealth;
    public float skillDamage;
    public float splashDamage;
    public float force;
    public float rotationalSpeed;
    public float splashRadius;
    public float timeBetweenFiring;
    public float TimeBeforeItsGone;
    public Animation Anim;
    public GameObject bullet;
    public int abilityLvl;
    public bool explodes;
    public bool stuns;
    public bool slows;
    public bool poisons;
    public bool activated;
}
