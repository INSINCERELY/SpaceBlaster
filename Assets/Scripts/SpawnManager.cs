using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 630f;
    private float spawnPosZ = 300;
    private float startDelay = 2;
    private float spawnInterval = 1.0f;
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnpos = new Vector3(Random.Range(-spawnRangeX,
        spawnRangeX), 0, spawnPosZ);
        Instantiate(enemyPrefabs[enemyIndex], spawnpos,
        enemyPrefabs[enemyIndex].transform.rotation);
    }
}
