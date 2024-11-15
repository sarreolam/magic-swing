using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float health=20;
    private Rigidbody2D enemyPrefab;
    public GameObject player;

    private int enemyType;
    
    public ScoreManager scoreManager;

    void Start()
    {
        enemyPrefab = GetComponent<Rigidbody2D>();
        enemyType = Random.Range(0, 0);

        if (scoreManager == null)
        {
            scoreManager = FindObjectOfType<ScoreManager>(); 
        }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player"); 
        }
    }


    private void Update()
    {
        if (enemyType == 0)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("bullet"))
        {
            health -= 5;
            Destroy(collision.gameObject);
            if(health<=0){
                Destroy(this.gameObject);
                scoreManager.IncreaseScore();
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


