using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// Controla los ataques del jefe y su movimiento vertical durante la batalla.
/// </summary>
public class BossAtack : MonoBehaviour
{

    private bool canAttack = false;
    private bool startBattle = false;
    private bool moveUp;
    private bool attack = true;
    private float speed = 5.0f;


    private float attackProbability = 0.05f;
    private float probabilityIncrement = 0.000000000005f;
    private float maxProbability = 0.8f;
    private Coroutine attackCoroutine;


    Vector3 topPostion;
    Vector3 bottomPostion;
    Vector3 atackRange = new Vector3(13, 0, 0);
    Vector3 originalPosition;

    public GameObject boss;


    /// Se ejecuta en cada cuadro; maneja el movimiento vertical y el comportamiento de ataque del jefe.
    void Update()
    {
        topPostion = new Vector3(1, 3, 0) + boss.transform.position;
        bottomPostion = new Vector3(1, -4, 0) + boss.transform.position;
        if (startBattle)
        {
            if (!canAttack)
            {
                if (moveUp)
                {
                    transform.position = Vector2.MoveTowards(transform.position, topPostion, speed * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, bottomPostion, speed * Time.deltaTime);
                }
                if (Vector3.Distance(transform.position, topPostion) <= 0)
                {
                    moveUp = false;
                }
                if (Vector3.Distance(transform.position, bottomPostion) <= 0)
                {
                    moveUp = true;
                }
                // Determina aleatoriamente si el jefe debe atacar.
                if (Random.Range(0, 600) < 1) //(Random.Range(0, 100) < 50)
                {
                    originalPosition = transform.position;
                    canAttack = true;
                }
                attackProbability = Mathf.Min(attackProbability + probabilityIncrement, maxProbability);
            }
            else
            {
                if (attack)
                {
                    transform.position = Vector2.MoveTowards(transform.position, originalPosition - atackRange, speed * 3 * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
                }
                if (Vector3.Distance(transform.position, originalPosition - atackRange) <= 0)
                {
                    attack = false;
                }
                if (Vector3.Distance(transform.position, originalPosition) <= 0)
                {
                    attack = true;
                    canAttack = false;
                }


            }


        }
    }


    /// Establece si el jefe puede atacar.

    /// <param name="canAttack">Estado de ataque.</param>
    public void setCanAttack(bool canAttack)
    {
        this.canAttack = canAttack;
    }


    /// Activa o desactiva la batalla del jefe.

    /// <param name="startBattle">Estado de la batalla.</param>
    public void setStartBattle(bool startBattle)
    {
        this.startBattle = startBattle;

    }


}
