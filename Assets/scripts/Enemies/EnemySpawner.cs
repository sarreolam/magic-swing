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
            StartCoroutine(spawnEnemy(Random.Range(0,3), Random.Range(0, 2)));
        }
    

    }

    IEnumerator spawnEnemy(int spawner, int enemyType)
    {
        canSpawn = false;
        if (enemyType == 0)
        {
            Instantiate(enemyPrefab, spawnPoints[spawner].transform.position,spawnPoints[spawner].transform.rotation , null);
        }else if(enemyType == 1)
        {
            Instantiate(enemyPrefab, spawnPoints[spawner].transform.position,spawnPoints[spawner].transform.rotation , spawnPoints[spawner].transform);
        }
        yield return new WaitForSeconds(spawnInterval);
        canSpawn = true;
    }

}
