using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectibles : MonoBehaviour
{

    public float healthAdd;
    public float XpAdd;
    public bool isInvisible = false;
    public float invisibleTime = 5f;

    //!either adds lvl or health
    public abstract void add();

    public abstract void OnTriggerEnter2D(Collider2D other);

    //!different invisible
    public abstract void Invisible();

}
