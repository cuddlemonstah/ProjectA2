using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerArtifactsScriptableObject", menuName = "ScriptableObjects/PlayerArtifacts")]
public class ArtifactStats : ScriptableObject
{
    public float moveSpeed;
    public float damage;
    public float health;
    public float mana;
    public string description;
    public bool activated;
}
