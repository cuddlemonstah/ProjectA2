using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehaviourInLvl : MonoBehaviour
{
    public GameObject[] enemy;
    private GameObject[] magicBall;
    private EnemyBehaviour[] enemyExist;
    public GameObject pivot;


    [SerializeField]
    private AttackStats[] atk;
    private bool ballInstantiated = false;
    float newX;
    int enemyNum;
    void Start()
    {
        Reset();
        StartCoroutine(insFireball());
        StartCoroutine(insLightning());
    }
    void Update()
    {

        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        enemyNum = enemy.Length;
        enemyExist = FindObjectsOfType<EnemyBehaviour>();
        //!Finding an object with tag Magic Ball
        magicBall = GameObject.FindGameObjectsWithTag("Magic Ball");
        //!Magic Ball
        BallIfTrue();

    }
    // Update is called once per frame

    //?Fireball Enum
    IEnumerator insFireball()
    {
        var delay = new WaitForSeconds(atk[0].timeBetweenFiring);
        while (true)
        {
            //! Fireball Ability -----------
            if (atk[0].activated == true && atk[0].abilityLvl == 1 && enemyNum > 0)
            {
                Instantiate(atk[0].bullet, transform.position, Quaternion.identity);
                yield return delay;
            }
            else if (atk[0].activated == true && atk[0].abilityLvl == 2 && enemyNum > 0)
            {
                atk[0].timeBetweenFiring = 3f;
                Instantiate(atk[0].bullet, transform.position, Quaternion.identity);
                yield return delay;
            }
            else if (atk[0].activated == true && atk[0].abilityLvl == 3 && enemyNum > 0)
            {
                atk[0].explodes = true;
                Instantiate(atk[0].bullet, transform.position, Quaternion.identity);
                yield return delay;
            }
            else if (atk[0].activated == true && atk[0].abilityLvl == 4 && enemyNum > 0)
            {
                Instantiate(atk[0].bullet, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(atk[0].bullet, transform.position, Quaternion.identity);
                yield return delay;
            }
            else if (atk[0].activated == true && atk[0].abilityLvl == 5 && enemyNum > 0)
            {
                atk[0].timeBetweenFiring = 2.4f;
                Instantiate(atk[0].bullet, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(atk[0].bullet, transform.position, Quaternion.identity);
                yield return delay;
            }
            else if (enemyNum == 0)
            {
                yield return null;
            }
            else
            {
                yield return null;
            }
        }
    }

    //? a Ball that Rotates
    void BallIfTrue()
    {
        if (atk[1].activated == true)
        {
            if (atk[1].abilityLvl == 1)
            {
                if (ballInstantiated == false)
                {
                    ballInstantiated = true;
                    pivot.transform.rotation = new Quaternion(0, 0, 0, 0);
                    Instantiate(atk[1].bullet, new Vector2(transform.localPosition.x + 2f, transform.localPosition.y), Quaternion.identity, pivot.transform);
                }
            }
            if (atk[1].abilityLvl == 2)
            {
                if (ballInstantiated == true)
                {
                    ballInstantiated = false;
                    pivot.transform.rotation = new Quaternion(0, 0, 0, 0);
                    Instantiate(atk[1].bullet, new Vector2(transform.localPosition.x - 2f, transform.localPosition.y), Quaternion.identity, pivot.transform);
                }
            }
            if (atk[1].abilityLvl == 3)
            {
                if (ballInstantiated == false)
                {
                    ballInstantiated = true;
                    pivot.transform.rotation = new Quaternion(0, 0, 0, 0);
                    magicBall[0].transform.position = new Vector2(transform.localPosition.x + 1, transform.localPosition.y + 2f);
                    magicBall[1].transform.position = new Vector2(transform.localPosition.x + 1, transform.localPosition.y - 2f);
                    Instantiate(atk[1].bullet, new Vector2(transform.localPosition.x - 2.2f, transform.localPosition.y), Quaternion.identity, pivot.transform);
                    atk[1].rotationalSpeed += 25;
                    atk[1].skillDamage += 5;
                }
            }
            if (atk[1].abilityLvl == 4)
            {
                if (ballInstantiated == true)
                {
                    ballInstantiated = false;
                    pivot.transform.rotation = new Quaternion(0, 0, 0, 0);
                    magicBall[0].transform.position = new Vector2(transform.localPosition.x, transform.localPosition.y + 2.5f);
                    magicBall[1].transform.position = new Vector2(transform.localPosition.x, transform.localPosition.y - 2.5f);
                    magicBall[2].transform.position = new Vector2(transform.localPosition.x + 2.5f, transform.localPosition.y);
                    Instantiate(atk[1].bullet, new Vector2(transform.localPosition.x - 2.5f, transform.localPosition.y), Quaternion.identity, pivot.transform);
                }
            }
            if (atk[1].abilityLvl == 5)
            {
                if (ballInstantiated == false)
                {
                    ballInstantiated = true;
                    pivot.transform.rotation = new Quaternion(0, 0, 0, 0);
                    magicBall[0].transform.position = new Vector2(transform.localPosition.x, transform.localPosition.y + 3.5f);
                    magicBall[1].transform.position = new Vector2(transform.localPosition.x, transform.localPosition.y - 3.5f);
                    magicBall[2].transform.position = new Vector2(transform.localPosition.x + 3.1f, transform.localPosition.y - 1.75f);
                    magicBall[3].transform.position = new Vector2(transform.localPosition.x - 3.1f, transform.localPosition.y + 1.75f);
                    Instantiate(atk[1].bullet, new Vector2(transform.localPosition.x + 3.1f, transform.localPosition.y + 1.75f), Quaternion.identity, pivot.transform);
                    Instantiate(atk[1].bullet, new Vector2(transform.localPosition.x - 3.1f, transform.localPosition.y - 1.75f), Quaternion.identity, pivot.transform);
                    atk[1].rotationalSpeed += 25;
                    atk[1].skillDamage += 5;
                }
            }
        }
    }

    //? Lightning strike
    IEnumerator insLightning()
    {
        //! Lightning Ability -----------
        while (true)
        {
            var delay = new WaitForSeconds(atk[2].timeBetweenFiring);
            if (atk[2].activated == true && atk[2].abilityLvl == 1)
            {
                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                yield return delay;
            }
            else if (atk[2].activated == true && atk[2].abilityLvl == 2)
            {
                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                yield return delay;
            }
            else if (atk[2].activated == true && atk[2].abilityLvl == 3)
            {
                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                yield return delay;
            }
            else if (atk[2].activated == true && atk[2].abilityLvl == 4)
            {

                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                yield return delay;
            }
            else if (atk[2].activated == true && atk[2].abilityLvl == 5)
            {
                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                Instantiate(atk[2].bullet, randomPos(), Quaternion.identity);
                yield return delay;
            }
            else
            {
                yield return null;
            }
        }
    }

    void Reset()
    {

        //? All abilities
        for (int i = 0; i < atk.Length; i++)
        {
            atk[i].abilityLvl = 0;
            atk[i].activated = false;
            atk[i].stuns = false;
            atk[i].slows = false;
        }

        //? Fireball Ability
        atk[0].skillDamage = 20f;
        atk[0].timeBetweenFiring = 3.5f;
        atk[0].explodes = false;

        //? Magic Ball
        atk[1].skillDamage = 10f;
        atk[1].rotationalSpeed = 50f;

        //?Lightning Ability
        atk[2].skillDamage = 100f;
        atk[2].splashRange = 0.7f;
        atk[2].timeBetweenFiring = 2f;
        atk[2].splashDamage = 60f;
        atk[2].explodes = true;
    }
    public Vector3 randomPos()
    {
        Vector3 randomPos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 10));
        return randomPos;
    }
}

