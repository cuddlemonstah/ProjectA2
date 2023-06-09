using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehaviour : MonoBehaviour
{
    public GameObject[] enemy;
    private GameObject[] magicBall;
    public GameObject pivot;

    //!Going to Change this to a list or an array when there are new abilities
    [SerializeField]
    private AttackStats[] atk;
    private bool enemyExist = false;
    private bool ballInstantiated = false;
    void Start()
    {
        Reset();
        StartCoroutine(insFireball());
    }
    void Update()
    {
        //!Finding an object with the tag enemy if true shoot, if null, dont
        if (enemy != null)
        {
            enemyExist = true;
            if (enemyExist == true)
            {
                enemy = GameObject.FindGameObjectsWithTag("Enemy");
            }
        }
        else
        {
            enemyExist = false;
        }
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
            if (atk[0].activated == true && enemyExist == true)
            {
                if (atk[0].abilityLvl == 1)
                {
                    Instantiate(atk[0].bullet, transform.position, Quaternion.identity);
                    yield return delay;
                }
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
                    Instantiate(atk[1].bullet, new Vector2(2, 0), Quaternion.identity, pivot.transform);
                }
            }
            if (atk[1].abilityLvl == 2)
            {
                if (ballInstantiated == true)
                {
                    ballInstantiated = false;
                    pivot.transform.rotation = new Quaternion(0, 0, 0, 0);
                    Instantiate(atk[1].bullet, new Vector2(-2, 0), Quaternion.identity, pivot.transform);
                }
            }
            if (atk[1].abilityLvl == 3)
            {
                if (ballInstantiated == false)
                {
                    ballInstantiated = true;
                    pivot.transform.rotation = new Quaternion(0, 0, 0, 0);
                    magicBall[0].transform.position = new Vector2(1, 2);
                    magicBall[1].transform.position = new Vector2(1, -2);
                    Instantiate(atk[1].bullet, new Vector2(-2.2f, 0), Quaternion.identity, pivot.transform);
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
                    magicBall[0].transform.position = new Vector2(0, 2.5f);
                    magicBall[1].transform.position = new Vector2(0, -2.5f);
                    magicBall[2].transform.position = new Vector2(2.5f, 0);
                    Instantiate(atk[1].bullet, new Vector2(-2.5f, 0), Quaternion.identity, pivot.transform);
                }
            }
            if (atk[1].abilityLvl == 5)
            {
                if (ballInstantiated == false)
                {
                    ballInstantiated = true;
                    pivot.transform.rotation = new Quaternion(0, 0, 0, 0);
                    magicBall[0].transform.position = new Vector2(0, 3.5f);
                    magicBall[1].transform.position = new Vector2(0, -3.5f);
                    magicBall[2].transform.position = new Vector2(3.1f, -1.75f);
                    magicBall[3].transform.position = new Vector2(-3.1f, 1.75f);
                    Instantiate(atk[1].bullet, new Vector2(3.1f, 1.75f), Quaternion.identity, pivot.transform);
                    Instantiate(atk[1].bullet, new Vector2(-3.1f, -1.75f), Quaternion.identity, pivot.transform);
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
