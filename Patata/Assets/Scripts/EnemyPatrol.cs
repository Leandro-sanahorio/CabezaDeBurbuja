using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f; // Movement speed of the enemy
    public Transform leftLimit; // Left boundary
    public Transform rightLimit; // Right boundary

    private bool movingRight = true; // Direction of movement
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
        // Move the enemy
        if (movingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            sprite.flipX = false; // Adjust based on your sprite orientation

            // Check if we reached the right limit
            if (transform.position.x >= rightLimit.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            sprite.flipX = true;

            // Check if we reached the left limit
            if (transform.position.x <= leftLimit.position.x)
            {
                movingRight = true;
            }
        }
    }

    // Optional: Visualize patrol limits in the editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(leftLimit.position, rightLimit.position);
    }
}
