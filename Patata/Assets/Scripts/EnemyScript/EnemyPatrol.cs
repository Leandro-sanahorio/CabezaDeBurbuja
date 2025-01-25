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
    public float timeRecharger=0;
    public int chaseSpeed;
    private EnemyStadistics enemyStadistics;
    private PlayerStadistics playerStadistics;
    public GameObject mainCharacter;
    public int enemyType;
    public GameObject enemy;
    public float nearChaseEnemy;



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
            case 4:
                DontPatrol();
                break;
        }
    }

    void Patrol()
    {
        if ((mainCharacter.transform.position - enemy.transform.position).magnitude>=nearChaseEnemy)
        {
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
        }else
        {
            enemy.transform.position=Vector2.MoveTowards(enemy.transform.position,mainCharacter.transform.position,chaseSpeed*Time.deltaTime);
        }
        
    }

    void CombinedPatrol()
    {
         if ((mainCharacter.transform.position - enemy.transform.position).magnitude>=nearChaseEnemy)
         {
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
         }else
         {
            enemy.transform.position=Vector2.MoveTowards(enemy.transform.position,mainCharacter.transform.position,chaseSpeed*Time.deltaTime);
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
        if ((mainCharacter.transform.position - enemy.transform.position).magnitude>=nearChaseEnemy)
        {
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
        }else
        {
            enemy.transform.position=Vector2.MoveTowards(enemy.transform.position,mainCharacter.transform.position,chaseSpeed*Time.deltaTime);
        }
    }

    void DontPatrol()
    {   
        // Mover enemigo
        if ((mainCharacter.transform.position - enemy.transform.position).magnitude>=nearChaseEnemy)
        {
            rb.velocity = new Vector2(0, 0);
        }else
        {
            enemy.transform.position=Vector2.MoveTowards(enemy.transform.position,mainCharacter.transform.position,chaseSpeed*Time.deltaTime);
        }
    }
}
