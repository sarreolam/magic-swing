using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D player;

    float horizontal;
    float vertical;

    public float speed = 20f;
    public float maxHealth = 173f;
    public float currentHealth;

    public bool canMove;
   


    public Collider2D topBoundary;
    public Collider2D bottomBoundary;
    public Collider2D leftBoundary;
    public Collider2D rightBoundary;

    public Health healthbar;
    public MenuManager menuManager;
    public AudioSource hitSound;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(canMove){
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
        if(currentHealth <= 0){
            menuManager.GameOver();
        }
    }


    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontal * speed, vertical * speed);
        player.velocity = movement;

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            currentHealth -= 23;
            hitSound.Play();
            healthbar.SetHealth(currentHealth);
            Destroy(collision.gameObject);
        }
    }

}
