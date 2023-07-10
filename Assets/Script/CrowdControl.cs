using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CrowdControl", menuName = "ScriptableObjects/CC's")]
public class CrowdControl : ScriptableObject
{
    public float stunDuration;
    public float slowDuration;
    public float poisonDuration;
}
