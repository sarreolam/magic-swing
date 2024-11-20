using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    public bool canSpawn = true;

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
        int enemyType = Random.Range(0, 2);
        for (int i = 0; i < 6; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position + new Vector3(0, Random.Range(-5, 5), 0), Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().setEnemyType(enemyType);
            yield return new WaitForSeconds(0.25f);
        }

        yield return new WaitForSeconds(spawnInterval);
        canSpawn = true;
    }

}
