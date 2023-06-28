using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerArtifactsScriptableObject", menuName = "ScriptableObjects/PlayerArtifacts")]
public class ArtifactStats : ScriptableObject
{
    public float moveSpeed;
    public float damage;
    public float health;
    public float healthRegen;
    public float mana;
    public float manaRegen;
    public float magicCoolDown;
    public string description;
    public bool activated;
}
