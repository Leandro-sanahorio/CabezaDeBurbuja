using UnityEngine;
using System.Collections;
public class EnemyPatrol : MonoBehaviour
{
    public bool movingRight = true;
    public bool movingFly = true;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public float leftLimit;
    public float rightLimit;
    public float FlyTopLimit;
    public float FlyBottomLimit;
    public float jumpSpeedPlayer = 5f;
    public float enemyMoveSpeed = 2f;
    public float enemyMoveSpeedFly = 1f;

    private float initialYPosition;
    public float fallSpeed = 3f;

    public float timeRecharger=0;

    private EnemyStadistics enemyStadistics;
    private PlayerStadistics playerStadistics;
    public GameObject mainCharacter;
    public int enemyType;


    void Start()
    {
        enemyStadistics= FindObjectOfType<EnemyStadistics>();
        playerStadistics= FindObjectOfType<PlayerStadistics>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        leftLimit=leftLimit+rb.position.x;
        rightLimit=rightLimit+rb.position.x;
    }

    void Update()
    {
        switch (enemyType)
        {
            case 1:
                Patrol();
                break;
            case 2:
                CombinedPatrol();
                break;
            case 3:
                CombinedPatrolJump();
                break;
        }
    }

    void Patrol()
    {
        // Mover enemigo
        if (movingRight)
        {
            rb.velocity = new Vector2(enemyStadistics.enemyMoveSpeed,  rb.velocity.y);
            sprite.flipX = false; // Ajuste basado en la orientación de sprite
            // Verifica si se alcanzo el limite derecho
            if (rb.position.x >= rightLimit)
            {
                movingRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-enemyStadistics.enemyMoveSpeed, rb.velocity.y);
            sprite.flipX = true;

            // Verifica si se alcanzo el limite derecho
            if (transform.position.x <= leftLimit)
            {
                movingRight = true;
            }
        }
    }

    void CombinedPatrol()
    {
    // Movimiento Horizontal (izquierda/derecha)
        if (movingRight)
        {
            rb.velocity = new Vector2(enemyStadistics.enemyMoveSpeed, rb.velocity.y);
            sprite.flipX = false; // Ajuste basado en la orientación del sprite
            if (rb.position.x >= rightLimit)
            {
                movingRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-enemyStadistics.enemyMoveSpeed, rb.velocity.y);
            sprite.flipX = true;
            if (rb.position.x <= leftLimit)
            {
                movingRight = true;
            }
        }

        // Movimiento Vertical (arriba/abajo)
        if (movingFly)
        {
            rb.velocity = new Vector2(rb.velocity.x, enemyStadistics.enemyMoveSpeedFly); // Mantener la velocidad horizontal mientras cambia la vertical
            if (rb.position.y >= FlyTopLimit)
            {
                movingFly = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -enemyStadistics.enemyMoveSpeedFly);
            if (rb.position.y <= FlyBottomLimit)
            {
                movingFly = true;
            }
        }
    }

    void CombinedPatrolJump()
    {   
        timeRecharger+=Time.deltaTime;
        if (timeRecharger>=3)
        {
            rb.velocity = new Vector2( rb.velocity.x, 5);
            timeRecharger=0;
        }
        // Mover enemigo
        if (movingRight)
        {
            rb.velocity = new Vector2(enemyStadistics.enemyMoveSpeed, rb.velocity.y);
            sprite.flipX = false; // Ajuste basado en la orientación de sprite
            // Verifica si se alcanzo el limite derecho
            if (rb.position.x >= rightLimit)
            {
                movingRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-enemyStadistics.enemyMoveSpeed, rb.velocity.y);
            sprite.flipX = true;

            // Verifica si se alcanzo el limite derecho
            if (transform.position.x <= leftLimit)
            {
                movingRight = true;
            }
        }
    }

}
