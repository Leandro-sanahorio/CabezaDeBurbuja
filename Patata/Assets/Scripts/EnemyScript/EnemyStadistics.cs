using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStadistics : MonoBehaviour
{

    public int life;
    public int damageTaken;
    public int damage;
    public float enemyMoveSpeed=2f;
    public float enemyMoveSpeedFly=0.3f;
    private PlayerStadistics playerStadistics;
    public float damageCooldown = 1f; // Tiempo entre daños (en segundos)
    
    private float lastDamageTime = 0f; // Última vez que se infligió daño

    public int enemyType;
    // Start is called before the first frame update
    
    public void takeDamage()
    {
        life=life-damageTaken;
    }

    public void FixedUpdate()
    {
        if(life<=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Verifica si el objeto en colisión tiene la etiqueta "Player"
        if (collision.collider.CompareTag("Player"))
        {
            if (playerStadistics == null)
            {
                Debug.LogError("PlayerStadistics no está asignado. Verifica que el jugador tenga el script necesario.");
                return;
            }

            // Comprueba si ya pasó el tiempo suficiente desde el último daño
            if (Time.time - lastDamageTime >= damageCooldown)
            {
                playerStadistics.takeDamage(damage); // Aplica el daño al jugador
                lastDamageTime = Time.time; // Actualiza el tiempo del último daño
            }
        }
    }

    private void Start()
    {
        playerStadistics= FindObjectOfType<PlayerStadistics>();
    }


}
