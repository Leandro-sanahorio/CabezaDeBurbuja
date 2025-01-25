using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public bool movingRight = true; // Direccion de movimiento
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public float leftLimit;
    public float rightLimit;
    private EnemyStadistics enemyStadistics;

    void Start()
    {
        enemyStadistics= FindObjectOfType<EnemyStadistics>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        leftLimit=leftLimit+rb.position.x;
        rightLimit=rightLimit+rb.position.x;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
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

     



    //Visualiza el limite de patrulla en el editor


}
