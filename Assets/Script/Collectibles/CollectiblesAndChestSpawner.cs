using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesAndChestSpawner : MonoBehaviour
{
    public List<GameObject> xp = new List<GameObject>();
    float randomNum;
    int rando;
    int smallMax = 150;
    public int currentSmall = 0;
    int mediumMax = 75;
    public int currentMedium = 0;

    int LargeMax = 3;
    public int currentLarge = 0;

    int LifeMax = 10;
    public int currentLife = 0;

    int InviMax = 10;
    public int currentInvi = 0;

    void Start()
    {
        StartCoroutine(SmallSpawn());
        StartCoroutine(MediumSpawn());
        StartCoroutine(LargeSpawn());
        StartCoroutine(LifeSpawn());
        StartCoroutine(InviSpawn());
    }


    IEnumerator SmallSpawn()
    {
        var delay = new WaitForSeconds(0.5f);

        while (true)
        {
            if (currentSmall < smallMax)
            {
                var randomPos = (Vector3)Random.insideUnitCircle * 30;
                randomPos += transform.position;
                Instantiate(xp[0], randomPos, transform.rotation);
                currentSmall++;
                yield return delay;
            }
            else
            {
                yield return null;
            }
        }
    }
    IEnumerator MediumSpawn()
    {
        var delay = new WaitForSeconds(5f);

        while (true)
        {
            if (currentMedium < mediumMax)
            {
                var randomPos = (Vector3)Random.insideUnitCircle * 30;
                randomPos += transform.position;
                Instantiate(xp[1], randomPos, transform.rotation);
                currentMedium++;
                yield return delay;
            }
            else
            {
                yield return null;
            }
        }
    }
    IEnumerator LargeSpawn()
    {
        var delay = new WaitForSeconds(50f);

        while (true)
        {
            if (currentLarge < LargeMax)
            {
                var randomPos = (Vector3)Random.insideUnitCircle * 30;
                randomPos += transform.position;
                Instantiate(xp[2], randomPos, transform.rotation);
                currentLarge++;
                yield return delay;
            }
            else
            {
                yield return null;
            }
        }
    }
    IEnumerator LifeSpawn()
    {
        var delay = new WaitForSeconds(20f);

        while (true)
        {
            if (currentLife < LifeMax)
            {
                var randomPos = (Vector3)Random.insideUnitCircle * 30;
                randomPos += transform.position;
                Instantiate(xp[3], randomPos, transform.rotation);
                currentLife++;
                yield return delay;
            }
            else
            {
                yield return null;
            }
        }
    }
    IEnumerator InviSpawn()
    {
        var delay = new WaitForSeconds(20f);

        while (true)
        {
            if (currentInvi < InviMax)
            {
                var randomPos = (Vector3)Random.insideUnitCircle * 30;
                randomPos += transform.position;
                Instantiate(xp[4], randomPos, transform.rotation);
                currentInvi++;
                yield return delay;
            }
            else
            {
                yield return null;
            }
        }
    }
}
