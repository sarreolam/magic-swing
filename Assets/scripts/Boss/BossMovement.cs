using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMovement : MonoBehaviour
{
    public float speed = 1.0f;

    private Vector3 bossPosition = new Vector3(8f, 0.0f, 0.0f);


    private bool startBattle = false;
    private bool playerIsMoving = false;

    public GameObject EnemySpawner;
    public GameObject EnemyUpSpawner;
    public GameObject Player;
    public GameObject BossArm;

    public Health healthbar;
    public float maxHealth = 2052f;
    private float health;
    public float damage = 23f;
    void Start()
    {
        EnemySpawner.GetComponent<EnemySpawner>().setCanSpawn(false);
        EnemyUpSpawner.GetComponent<EnemyUpSpawner>().setCanSpawn(false);
        Player.GetComponent<Shooting>().setCanShoot(false);
        Player.GetComponent<Player>().setCanMove(false);

        health = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        if (!startBattle)
        {
            if (Vector3.Distance(transform.position, bossPosition) > 0 || !playerIsMoving)
            {
                transform.position = Vector2.MoveTowards(transform.position, bossPosition, speed * Time.deltaTime);
            }
            else
            {
                EnemySpawner.GetComponent<EnemySpawner>().setCanSpawn(true);
                EnemyUpSpawner.GetComponent<EnemyUpSpawner>().setCanSpawn(true);
                Player.GetComponent<Shooting>().setCanShoot(true);
                Player.GetComponent<Player>().setCanMove(true);
                BossArm.GetComponent<BossAtack>().setStartBattle(true);
                startBattle = true;
            }
        }
    }

    public void setPlayerIsMoving(bool playerIsMoving)
    {
        this.playerIsMoving = playerIsMoving;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health -= damage;
            healthbar.SetHealth(health - damage);
            Destroy(collision.gameObject);
        }


    }


}
