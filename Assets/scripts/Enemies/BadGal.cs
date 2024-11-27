using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BadGal : MonoBehaviour
{

    public float speed = 10f;
    private Coroutine moveCoroutine;
    public Timeline timeline;

    public Vector3 outSidePosition = new Vector3(15,0,0);
    public Vector3 insidePosition = new Vector3(4,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CallMoveToCenter()
    {
        if (moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveToCenter());
        }
    }

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

    public void CallMoveToSide()
    {
        if (moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveToSide());
        }
    }
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
