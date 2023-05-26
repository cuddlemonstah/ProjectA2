using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAbility : MonoBehaviour
{

    //?UI only "its the cards that you can see when you level up"
    public Transform[] pos;
    int Rand;
    public List<GameObject> ability = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            int randomNumber = Random.Range(0, ability.Count);
            GameObject newA = Instantiate(ability[randomNumber], pos[i].position, transform.rotation);
            newA.transform.SetParent(GameObject.FindGameObjectWithTag("Ability Sheet").transform, false);
        }
    }

}

