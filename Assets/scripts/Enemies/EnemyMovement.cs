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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.transform.parent != null)
        {
            if (collision.transform.parent.name == "Boundaries")
            {
                Destroy(this.gameObject);

            }
        }

    }
}
