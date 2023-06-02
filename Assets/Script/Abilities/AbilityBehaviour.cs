using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehaviour : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform parent;

    //!Going to Change this to a list or an array when there are new abilities
    [SerializeField]
    private AttackStats[] atk;
    private bool enemyExist = false;

    public float x, y, z;
    void Start()
    {
        for (int i = 0; i < atk.Length; i++)
        {
            atk[i].abilityLvl = 0;
            atk[i].activated = false;
        }
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

            if (atk[1].activated == true)
            {
                if (atk[1].abilityLvl == 1)
                {
                    Instantiate(atk[1].bullet, new Vector3(x, y, z), Quaternion.identity, parent);
                    yield return new WaitForSeconds(100f);
                }
            }


        }

    }

    void rotationalBall()
    {
        if (atk[1].activated == true)
        {
            if (atk[1].abilityLvl == 1)
            {
                Instantiate(atk[1].bullet, new Vector3(0, 0, 1), Quaternion.identity, parent);
            }
        }
    }
}
