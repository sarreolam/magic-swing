using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D player;
    public Shooting shooting;

    float horizontal;
    float vertical;

    public float speed = 20f;
    public float maxHealth = 173f;
    public float currentHealth;

    public bool canMove;
    private bool gameStart = false;

    public Collider2D topBoundary;
    public Collider2D bottomBoundary;
    public Collider2D leftBoundary;
    public Collider2D rightBoundary;

    public Health healthbar;
    public MenuManager menuManager;
    public AudioSource hitSound;
    public float invincibilityDuration = 1f;
    private bool isInvincible = false;

    private Coroutine moveCoroutine;
    public textBoxManager textBoxManager;
    public TimerManager timerManager;

    public EnemySpawner enemySpawner;
    public EnemyUpSpawner enemyUpSpawner;

    public Timeline timeline;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        enemySpawner.canSpawn = false;
        enemyUpSpawner.canSpawn = false;
        shooting.setCanShoot(false);
        
    }

    void Update()
    {
        if (canMove)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
        if (currentHealth <= 0)
        {
            menuManager.GameOver();
        }
    }


    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontal * speed, vertical * speed);
        player.velocity = movement;

        if (gameStart)
        {
            ClampPlayerWithinBounds();
        }
    }
    private void ClampPlayerWithinBounds()
    {

        float minX = leftBoundary.bounds.max.x + 1.2f;
        float maxX = rightBoundary.bounds.min.x - 1;
        float minY = bottomBoundary.bounds.max.y + 0.8f;
        float maxY = topBoundary.bounds.min.y - 1;

        Vector3 clampedPosition = player.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);

        player.position = clampedPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isInvincible)
        {
            if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("enemyBullet"))
            {
                currentHealth -= 23;
                hitSound.Play();
                healthbar.SetHealth(currentHealth);
                Destroy(collision.gameObject);
                StartCoroutine(InvincibilityFrames());
            }
            if (collision.gameObject.CompareTag("boss") || collision.gameObject.CompareTag("bossArm"))
            {
                currentHealth -= 33;
                hitSound.Play();
                healthbar.SetHealth(currentHealth);
                StartCoroutine(InvincibilityFrames());
            }
        }
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
        canMove = false;
        horizontal = 0;
        vertical = 0;
        while (transform.position != Vector3.zero)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);
            yield return Time.deltaTime * 0.1;
        }

        timeline.Next();
        transform.position = Vector3.zero;
        moveCoroutine = null;
    }

    //public void StartTextBoxes()
    //{
    //    textBoxManager.EnableTextBox();
    //    textBoxManager.SetGameStart(true);
    //}


    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
        if (!canMove )
        {
            horizontal = 0;
            vertical = 0;
        }
    }

    public void SetGameStart(bool gameStart)
    {
        if (this.gameStart != gameStart)
        {
            this.gameStart = gameStart;
            SetCanMove(gameStart);
            shooting.setCanShoot(gameStart);
            enemySpawner.SetCanSpawn(gameStart);
            enemyUpSpawner.setCanSpawn(gameStart);
            if (timerManager != null) {
                timerManager.SetTimerOn(gameStart);
            }
            if (!gameStart) {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
                for (int i = 0; i < enemies.Length; i++)
                {
                    Destroy(enemies[i]);
                }
            }
        }
    }

    IEnumerator InvincibilityFrames()
    {
        isInvincible = true;
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        if (spriteRenderers != null)
        {
            for (int i = 0; i < 5; i++)
            {
                foreach (SpriteRenderer spriteRenderer in spriteRenderers)
                {
                    spriteRenderer.enabled = false;
                }
                yield return new WaitForSeconds(invincibilityDuration / 10);

                foreach (SpriteRenderer spriteRenderer in spriteRenderers)
                {
                    spriteRenderer.enabled = true;
                }
                yield return new WaitForSeconds(invincibilityDuration / 10);
            }
        }
        else
        {
            yield return new WaitForSeconds(invincibilityDuration);
        }

        isInvincible = false;
    }

}
