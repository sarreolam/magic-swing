using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerMovement : MonoBehaviour
{
    public float distance = 2f;  
    public float speed = 2f;  

    private Vector2 startPos;
    private bool movingUp = true;
    
    void Start()
    {
        startPos = transform.position;
    }

   
    void Update()
    {
        if(movingUp){
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (Vector2.Distance(startPos, transform.position) >= distance)
        {
            movingUp = !movingUp;
        }
    }
}
