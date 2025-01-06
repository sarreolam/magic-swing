using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// Controla el movimiento de un personaje llamado "BadGal" entre posiciones específicas en el escenario.

public class BadGal : MonoBehaviour
{

    public float speed = 10f;
    private Coroutine moveCoroutine;
    public Timeline timeline;

    public Vector3 outSidePosition = new Vector3(15,0,0);
    public Vector3 insidePosition = new Vector3(4,0,0);


    /// Inicia el movimiento del personaje hacia el centro del escenario.

    public void CallMoveToCenter()
    {
        if (moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveToCenter());
        }
    }

    /// Corrutina que mueve al personaje desde su posición actual hacia el centro.

    IEnumerator MoveToCenter()
    {
        while (transform.position !=insidePosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, insidePosition, speed * Time.deltaTime);
            yield return Time.deltaTime * 0.1;
        }

        timeline.Next();
        transform.position = insidePosition;
        moveCoroutine = null;
    }

    /// Inicia el movimiento del personaje hacia el borde del escenario.

    public void CallMoveToSide()
    {
        if (moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveToSide());
        }
    }

    /// Corrutina que mueve al personaje desde su posición actual hacia un borde del escenario.

    IEnumerator MoveToSide()
    {
        while (transform.position != outSidePosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, outSidePosition, speed * Time.deltaTime);
            yield return Time.deltaTime * 0.1;
        }

        timeline.Next();
        transform.position = outSidePosition;
        moveCoroutine = null;
    }
}
