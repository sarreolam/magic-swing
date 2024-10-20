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


    public Collider2D topBoundary;
    public Collider2D bottomBoundary;
    public Collider2D leftBoundary;
    public Collider2D rightBoundary;



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
        Vector2 movement = new Vector2(horizontal * speed, vertical * speed);
        player.velocity = movement;

        // Clamp the player's position within the boundary
        ClampPlayerWithinBounds();
    }
    private void ClampPlayerWithinBounds()
    {
        // Get the min and max limits from each boundary's bounds
        float minX = leftBoundary.bounds.max.x + 1.2f;
        float maxX = rightBoundary.bounds.min.x -1;
        float minY = bottomBoundary.bounds.max.y + 0.8f;
        float maxY = topBoundary.bounds.min.y - 1;

        // Get the player's current position
        Vector3 clampedPosition = player.position;

        // Clamp the X and Y positions to stay within the boundaries
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);

        // Apply the clamped position to the player
        player.position = clampedPosition;
    }



}
