using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float health=20;
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
            health -= 5;
            Destroy(collision.gameObject);
            if(health<=0){
                Destroy(this.gameObject);
            }
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
