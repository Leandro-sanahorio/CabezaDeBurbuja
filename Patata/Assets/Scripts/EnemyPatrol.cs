using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento de enemigo
    public Transform leftLimit; // Limite izquierdo
    public Transform rightLimit; // Limite Derecho

    private bool movingRight = true; // Direccion de movimiento
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
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
            rb.velocity = new Vector2(speed, rb.velocity.y);
            sprite.flipX = false; // Ajuste basado en la orientación de sprite

            // Verifica si se alcanzo el limite derecho
            if (transform.position.x >= rightLimit.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            sprite.flipX = true;

            // Verifica si se alcanzo el limite derecho
            if (transform.position.x <= leftLimit.position.x)
            {
                movingRight = true;
            }
        }
    }

    //Visualiza el limite de patrulla en el editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(leftLimit.position, rightLimit.position);
    }
}
