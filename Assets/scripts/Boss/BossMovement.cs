using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



/// Controla el movimiento y comportamiento general del jefe durante la batalla.

public class BossMovement : MonoBehaviour
{
    public float speed = 1.0f;

    private Vector3 bossPosition = new Vector3(8f, 0.0f, 0.0f);

    private Vector3 bossDefeatPostirion = new Vector3(8, -10, 0);


    private bool startBattle = false;
    private bool playerIsMoving = false;

    public GameObject EnemySpawner;
    public GameObject EnemyUpSpawner;
    public GameObject Player;
    public GameObject BossArm;
    public BoxCollider2D BossCollider;

    private Coroutine moveCoroutine;

    public Health healthbar;
    public float maxHealth = 2052f;
    private float health;
    public float damage = 23f;

    public Timeline timeline;

    void Start()
    {

        health = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

 
    /// Establece si el jugador está en movimiento.

    public void SetPlayerIsMoving(bool playerIsMoving)
    {
        this.playerIsMoving = playerIsMoving;
    }


    /// Detecta colisiones con proyectiles y aplica daño al jefe.

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health -= damage;
            healthbar.SetHealth(health - damage);
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                BossCollider.enabled = false;   
                Player.GetComponent<Player>().SetGameStart(false);
                timeline.CallCameraShake(2, 5);
                timeline.Next();
                SetStartBattle(false);



            }
        }
    }


    /// Inicia el movimiento del jefe hacia su posición inicial de batalla.


    public void CallMoveToPosition()
    {
        if (moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveToPosition());
        }
    }

    /// Corrutina para mover al jefe hacia su posición inicial de batalla.


    IEnumerator MoveToPosition()
    {

        while (transform.position != bossPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, bossPosition, speed * Time.deltaTime);
            yield return Time.deltaTime * 0.1;
        }

        timeline.Next();
        transform.position =bossPosition;
        moveCoroutine = null;
    }



    /// Inicia el movimiento del jefe hacia su posición tras ser derrotado.

    public void CallDefeat()
    {
        if (moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveToDefeat());
        }
    }



    /// Corrutina para mover al jefe hacia su posición tras ser derrotado.

    IEnumerator MoveToDefeat()
    {

        while (transform.position != bossDefeatPostirion)
        {
            transform.position = Vector2.MoveTowards(transform.position, bossDefeatPostirion, 2f *speed * Time.deltaTime);
            yield return Time.deltaTime * 0.1;
        }

        timeline.Next();
        transform.position = bossDefeatPostirion;
        moveCoroutine = null;
    }



    /// Activa o desactiva la batalla del jefe. 
 
    public void SetStartBattle(bool startBattle)
    {
        BossArm.GetComponent<BossAtack>().setStartBattle(startBattle);
    }


}
