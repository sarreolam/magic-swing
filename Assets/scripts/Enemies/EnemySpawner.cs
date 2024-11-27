using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject toastEnemyPrefab;
    public GameObject catEnemyPrefab;
    public float spawnInterval;
    public float spawnFrequency;
    public bool canSpawn = true;

    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        canSpawn = false;
        int enemyType = Random.Range(0, 2);
        spawnFrequency = enemyType == 0 ? Random.Range(1, 6) : Random.Range(1, 3);
        for (int i = 0; i < spawnFrequency; i++)
        {
            if (enemyType == 0)
            {
                GameObject enemy = Instantiate(toastEnemyPrefab, transform.position + new Vector3(0, Random.Range(-5, 5), 0), Quaternion.identity);
                enemy.GetComponent<EnemyMovement>().setEnemyType(enemyType);
                yield return new WaitForSeconds(0.25f);
            }
            else if (enemyType == 1)
            {
                GameObject enemy = Instantiate(catEnemyPrefab, transform.position + new Vector3(0, Random.Range(-5, 5), 0), Quaternion.identity);
                enemy.GetComponent<EnemyMovement>().setEnemyType(enemyType);
                yield return new WaitForSeconds(0.25f);
            }

        }

        yield return new WaitForSeconds(spawnInterval);
        canSpawn = true;
    }

    public void SetCanSpawn(bool canSpawn)
    {
        this.canSpawn = canSpawn;
        this.enabled = canSpawn;
    }

}
