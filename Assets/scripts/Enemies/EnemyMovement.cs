using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D enemyPrefab;

    void Start()
    {
        enemyPrefab = GetComponent<Rigidbody2D>();
        enemyPrefab.velocity = -transform.right * speed;
    }
}
