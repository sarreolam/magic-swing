using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float projectileSpeed;
    public float shootingCooldown;
    public float health = 20;
    private Rigidbody2D enemyPrefab;
    public GameObject projectilePrefab;
    public GameObject player;

    private int enemyType;

    public ScoreManager scoreManager;

    Vector2 spawnPosition;
    Vector2 stopPosition;
    private bool movingLeft = true;
    private bool shooting = false;

    void Start()
    {
        enemyPrefab = GetComponent<Rigidbody2D>();
        //enemyType = Random.Range(0, 2);
        spawnPosition = transform.position;
        stopPosition = transform.position - new Vector3(7, 0, 0);

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
        else if (enemyType == 1)
        {
            if (movingLeft)
            {
                MoveTowards(stopPosition);
                if (Vector2.Distance(transform.position, stopPosition) < 0.1f)
                {
                    movingLeft = false;
                    shooting = true;
                    StartCoroutine(Shooting());
                }
            }
            else if (!shooting)
            {
                MoveTowards(spawnPosition);
                if (Vector2.Distance(transform.position, spawnPosition) < 0.1f)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else if (enemyType == 2)
        {
            transform.position += (Vector3)Vector2.up * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health -= 5;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
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

    void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    IEnumerator Shooting()
    {
        Vector3 spawnOffset = new Vector3(1f, 0, 0);
        GameObject bulletToDestroy = Instantiate(projectilePrefab, transform.position - spawnOffset, transform.rotation);
        Destroy(bulletToDestroy, 3);
        yield return new WaitForSeconds(shootingCooldown);
        shooting = false;
    }

    public void setEnemyType(int type)
    {
        enemyType = type;
    }

}


