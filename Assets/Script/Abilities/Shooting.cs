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
    ProjectileScript rico;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    // Start is called before the first frame update
    void Start()
    {
        rico = FindObjectOfType<ProjectileScript>();
        attacks.abilityLvl = 1;
        attacks.activated = true;
        attacks.skillDamage = 0;
        attacks.timeBetweenFiring = 0.7f;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attacks.attackName == "Magic")
        {
            if (attacks.abilityLvl == 1 && attacks.activated == true)
            {
                magicLvl1();
            }
            else if (attacks.abilityLvl == 2 && attacks.activated == true)
            {
                StartCoroutine(magicLvl2());
            }
            else if (attacks.abilityLvl == 3 && attacks.activated == true)
            {
                StartCoroutine(magicLvl3());
            }
            else if (attacks.abilityLvl == 4 && attacks.activated == true)
            {
                StartCoroutine(magicLvl4());
            }
            else if (attacks.abilityLvl == 5 && attacks.activated == true)
            {
                StartCoroutine(magicLvl5());
            }
        }
    }

    void magicLvl1()
    {
        MousePos();
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
        }
    }
    IEnumerator magicLvl2()
    {
        MousePos();
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(.1f);
            Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
        }
    }

    IEnumerator magicLvl3()
    {
        ProjectileScript.ricochet = true;
        MousePos();
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(.1f);
            Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
        }
    }
    IEnumerator magicLvl4()
    {

        ProjectileScript.ricochet = true;
        ProjectileScript.collisionCountMax = 5;
        MousePos();
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(.1f);
            Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(.1f);
            Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
        }
    }
    IEnumerator magicLvl5()
    {
        ProjectileScript.ricochet = true;
        ProjectileScript.collisionCountMax = 5;
        MousePos();
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(.1f);
            Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(.1f);
            Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(.1f);
            Instantiate(attacks.bullet, bulletTransform.position, Quaternion.identity);
        }
    }

    void MousePos()
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
    }
}
