using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D player;

    float horizontal;
    float vertical;

    public float speed = 20f;

    public bool canMove;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
    }


    private void FixedUpdate()
    {
        player.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
