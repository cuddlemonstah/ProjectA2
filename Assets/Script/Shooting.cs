using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private Camera mainCamera;
    private Vector3 mousePos;
    [SerializeField]
    private AttackStats attacks;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attacks.abilityLvl == 1 && attacks.activated == true)
        {
            magicLvl1();
        }
        else if (attacks.abilityLvl == 2 && attacks.activated == true)
        {
            magicLvl2();
        }
    }

    void magicLvl1()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rot = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
        }
    }
    void magicLvl2()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rot = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            StartCoroutine(anotherBullet());

        }
    }

    void magicLvl3()
    {

    }
    void magicLvl4()
    {

    }
    void magicLvl5()
    {

    }

    IEnumerator anotherBullet()
    {
        Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
        yield return new WaitForSeconds(.1f);
        Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
    }
}
