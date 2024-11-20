using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D enemyBulletPrefab;

    public GameObject player;

    void Start()
    {

        if (player == null)
            player = GameObject.FindWithTag("Player");
        enemyBulletPrefab = GetComponent<Rigidbody2D>();
        Vector2 spawnPosition = transform.position;
        Vector2 playerPosition = player.transform.position;
        Vector2 direction = (playerPosition - spawnPosition).normalized;
        enemyBulletPrefab.velocity = direction * speed;
    }
}
