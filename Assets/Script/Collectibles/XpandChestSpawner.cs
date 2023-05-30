using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpandChestSpawner : MonoBehaviour
{
    public List<GameObject> xp = new List<GameObject>();
    float randomNum;
    int rando;
    void Start()
    {
        InvokeRepeating("Spawn", 0f, 1f);
    }

    private void Spawn()
    {
        rando = Random.Range(0, xp.Count);
        var randomPos = (Vector3)Random.insideUnitCircle * 30;
        randomPos += transform.position;
        Instantiate(xp[rando], randomPos, transform.rotation);
    }
}
