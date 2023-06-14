using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesAndChestSpawner : MonoBehaviour
{
    public List<GameObject> Collective = new List<GameObject>();
    float randomNum;
    int rando;
    int smallMax = 500;
    public int currentSmall = 0;
    int mediumMax = 250;
    public int currentMedium = 0;

    int LargeMax = 20;
    public int currentLarge = 0;

    int LifeMax = 30;
    public int currentLife = 0;

    int InviMax = 30;
    public int currentInvi = 0;
    int ChestMax = 3;
    public int currentChest = 0;

    void Start()
    {
        StartCoroutine(SmallSpawn());
        StartCoroutine(MediumSpawn());
        StartCoroutine(LargeSpawn());
        StartCoroutine(LifeSpawn());
        StartCoroutine(InviSpawn());
        StartCoroutine(ChestSpawn());
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
                Instantiate(Collective[0], randomPos, transform.rotation);
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
                Instantiate(Collective[1], randomPos, transform.rotation);
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
                Instantiate(Collective[2], randomPos, transform.rotation);
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
                Instantiate(Collective[3], randomPos, transform.rotation);
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
                Instantiate(Collective[4], randomPos, transform.rotation);
                currentInvi++;
                yield return delay;
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator ChestSpawn()
    {

        var delay = new WaitForSeconds(Random.Range(75f, 120f));

        while (true)
        {
            if (currentChest < ChestMax)
            {
                var randomPos = (Vector3)Random.insideUnitCircle * 50;
                randomPos += transform.position;
                Instantiate(Collective[5], randomPos, transform.rotation);
                currentChest++;
                yield return delay;
            }
            else
            {
                yield return null;
            }
        }
    }
}
