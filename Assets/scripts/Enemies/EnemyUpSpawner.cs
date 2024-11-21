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
        int enemyType = 2;
        for (int i = 0; i < Random.Range(1, 3); i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position + new Vector3(Random.Range(0, 5),0, 0), Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().setEnemyType(enemyType);
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(spawnInterval);
        canSpawn = true;
    }

    public void setCanSpawn(bool canSpawn)
    {
        this.canSpawn = canSpawn;
    }


}
