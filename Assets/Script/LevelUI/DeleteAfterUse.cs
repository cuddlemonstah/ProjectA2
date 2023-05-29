using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterUse : MonoBehaviour
{

    void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnDisable()
    {
        Destroy(this.gameObject);
    }
}
