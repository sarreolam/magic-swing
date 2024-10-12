using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    public Transform[] spawnPoints;
    private bool canSpawn=true;

  
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(spawnEnemy());
        }

    }

    IEnumerator spawnEnemy()
    {
        canSpawn = false;
        Instantiate(enemyPrefab, spawnPoints[Random.Range(0, 3)]);
        yield return new WaitForSeconds(spawnInterval);
        canSpawn = true;
    }

}
