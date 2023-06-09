using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactUI : MonoBehaviour
{
    public Transform[] pos;
    public List<GameObject> artifacts = new List<GameObject>();
    UIManager UI;
    int randomNumber;
    bool reset;

    void OnEnable()
    {
        reset = true;
        if (reset == true)
        {
            for (int i = 0; i < pos.Length; i++)
            {
                randomNumber = Random.Range(0, artifacts.Count);
                GameObject newA = Instantiate(artifacts[randomNumber], pos[i].position, transform.rotation);
                newA.transform.SetParent(GameObject.FindGameObjectWithTag("Ability Sheet").transform, false);
            }
        }
    }

    void OnDisable()
    {

        reset = false;
        if (reset == false)
        {
            for (int i = 0; i < pos.Length; i++)
            {
                randomNumber = 0;
            }
        }
    }
}
