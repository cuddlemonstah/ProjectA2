using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotationalProjectile : MonoBehaviour
{
    public GameObject test;
    CircleCollider2D radius;
    // Start is called before the first frame update
    void Start()
    {
        radius = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = new Vector3(radius.radius, radius.radius, 0);
            Instantiate(test, pos, Quaternion.identity);
            Debug.Log(radius.radius);
        }
    }
}
