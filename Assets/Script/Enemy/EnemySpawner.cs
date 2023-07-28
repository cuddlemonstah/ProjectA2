using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //!cache
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemyPrefab;

    [SerializeField] float time = 0f;
    [SerializeField] public static float repeatRate = 3f;

    private float minutes, seconds;
    void Start()
    {
        InvokeRepeating("spawnEnemy", time, repeatRate);
        InvokeRepeating("changeRepeatRate", 60f, 60f);
    }

    void Update()
    {
        if (minutes == 7)
        {
            CancelInvoke("changeRepeatRate");
        }
        Debug.Log(repeatRate);
    }

    [System.Obsolete]
    void spawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemyPrefab.Length);
        int randonSpawnPoint = Random.RandomRange(0, spawnPoints.Length);
        Instantiate(enemyPrefab[randomEnemy], spawnPoints[randonSpawnPoint].position, Quaternion.identity);
    }

    void changeRepeatRate()
    {
        if (minutes <= 3)
        {
            repeatRate -= 0.5f;
        }
        else
        {
            repeatRate -= 0.3f;
        }
    }

    public void setTimeMinutes(float minutes, float seconds)
    {
        this.minutes = minutes;
        this.seconds = seconds;
    }

}
