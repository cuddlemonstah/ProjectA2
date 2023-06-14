using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehaviour : MonoBehaviour
{
    public GameObject[] enemy;
    private GameObject[] magicBall;
    private EnemyBehaviour[] enemyExist;
    public GameObject pivot;

    //!Going to Change this to a list or an array when there are new abilities
    [SerializeField]

    private AttackStats[] atk;
    private bool ballInstantiated = false;
    float newX;
    int enemyNum;
    void Start()
    {
        Reset();
        StartCoroutine(insFireball());
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

    //?Fireball Enum might change later
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

    void Reset()
    {

        //? All abilities
        for (int i = 0; i < atk.Length; i++)
        {
            atk[i].abilityLvl = 0;
            atk[i].activated = false;
        }

        //? Fireball Ability
        atk[0].skillDamage = 20f;

        //? Magic Ball
        atk[1].skillDamage = 10f;
        atk[1].rotationalSpeed = 50f;
    }
}
