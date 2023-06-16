using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //!cache
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemyPrefab;

    [SerializeField] float time = 0f;
    [SerializeField] float repeatRate = 1f;
    void Start()
    {
        InvokeRepeating("spawnEnemy", time, repeatRate);
    }

    void Update()
    {
    }

    [System.Obsolete]
    void spawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemyPrefab.Length);
        int randonSpawnPoint = Random.RandomRange(0, spawnPoints.Length);

        Instantiate(enemyPrefab[randomEnemy], spawnPoints[randonSpawnPoint].position, Quaternion.identity);
    }
}
