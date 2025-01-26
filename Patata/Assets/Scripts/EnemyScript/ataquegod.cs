using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormAttack : MonoBehaviour
{
    public Transform player;           // Referencia al jugador
    public float speed = 2f;           // Velocidad de movimiento del gusano
    public float jumpHeight = 3f;      // Altura m�xima para el salto (embestida)
    public float attackDistance = 1f;  // Distancia para detectar si est� cerca del jugador y atacar

    private bool isAttacking = false;

    private void Update()
    {
        // Si el gusano est� atacando, no hacer nada m�s
        if (isAttacking) return;

        // Mover al gusano hacia el jugador
        MoveTowardsPlayer();

        // Si est� cerca del jugador, empieza la embestida
        if (Vector2.Distance(transform.position, player.position) < attackDistance)
        {
            StartCoroutine(Attack());
        }
    }

    // Mover al gusano hacia la direcci�n del jugador
    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    // Coroutine que maneja la embestida del gusano
    IEnumerator Attack()
    {
        isAttacking = true;

        // Subir hacia el jugador
        float startHeight = transform.position.y;
        float targetHeight = player.position.y + jumpHeight;

        while (transform.position.y < targetHeight)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, targetHeight), speed * Time.deltaTime);
            yield return null;
        }

        // Embestir hacia el jugador
        while (transform.position.x != player.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
            yield return null;
        }

        // Regresar a la posici�n original
        transform.position = new Vector2(transform.position.x, startHeight);

        isAttacking = false;
    }
}
