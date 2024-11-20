using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    public bool canSpawn=true;

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
        for (int i = 0; i < 3; i++)
        {
        Instantiate(enemyPrefab, transform.position + new Vector3(Random.Range(0, 5),0, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(spawnInterval);
        canSpawn = true;
    }

}
