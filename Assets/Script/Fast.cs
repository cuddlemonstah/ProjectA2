using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fast : MonoBehaviour
{
    [SerializeField][Range(1, 10)] float time;

    void Update()
    {
        Time.timeScale = time;
    }
}
