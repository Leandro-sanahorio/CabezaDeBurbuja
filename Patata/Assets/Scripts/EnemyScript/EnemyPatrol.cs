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


    //Configura referencias globales a otros objetos importantes en la escena, como el jugador, las estadísticas del enemigo y su movimiento.
    void Start()
    {
        enemyStadistics= FindObjectOfType<EnemyStadistics>();
        playerStadistics= FindObjectOfType<PlayerStadistics>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        leftLimit=leftLimit+rb.position.x;
        rightLimit=rightLimit+rb.position.x;
    }

    //Se usa para darle algun tipo de movimiento al enemigo dependiendo del caso
    void Update()
    {
        switch (enemyType)
        {
            //Movimiento basico de             
            case 1:
                Patrol();
                break;
            //Cucaracha              
            case 2:
                CombinedPatrol();
                break;
            //Pelusa                
            case 3:
                CombinedPatrolJump();
                break;
            //Polilla    
            case 4:
                DontPatrol();
                break;
        }
    }


    //El enemigo se mueve de derecha a izquierda
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

    //El enemigo se mueve por los aires de derecha a izquierda y tambien de arriba hacia abajo
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
    

    //El enemigo se mueve de izquierda a derecha con algun salto periodico
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

    //El enemigo se queda en reposo hasta que el jugador este cerca
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