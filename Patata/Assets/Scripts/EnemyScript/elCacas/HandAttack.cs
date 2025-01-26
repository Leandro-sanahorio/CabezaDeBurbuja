/*using UnityEngine;

public class HandAttack : MonoBehaviour
{
    public float ascendSpeed = 5f; // Velocidad de ascenso
    public float descendSpeed = 3f; // Velocidad de descenso
    public float ascendHeight = 3f; // Altura máxima de ascenso desde la posición inicial
    public float delayBeforeReturn = 1f; // Tiempo antes de volver a descender

    private Vector2 initialPosition; // Posición inicial del objeto
    private Vector2 targetPosition; // Posición máxima de ascenso
    private bool isTriggered = false; // Si el jugador está en el rango
    private bool isReturning = false; // Si está descendiendo a su posición inicial

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = rb.position;
        targetPosition = new Vector2(initialPosition.x, initialPosition.y + ascendHeight);
    }

    void FixedUpdate()
    {
        if (isTriggered && !isReturning)
        {
            Ascend();
        }
        else if (isReturning)
        {
            Descend();
        }
    }

    void Ascend()
    {
        rb.velocity = new Vector2(0, ascendSpeed);

        // Si alcanza la altura máxima, detén el movimiento
        if (rb.position.y >= targetPosition.y)
        {
            rb.velocity = Vector2.zero;
            Invoke("StartReturning", delayBeforeReturn); // Espera antes de descender
        }
    }

    void Descend()
    {
        rb.velocity = new Vector2(0, -descendSpeed);

        // Si alcanza la posición inicial, detén el movimiento
        if (rb.position.y <= initialPosition.y)
        {
            rb.velocity = Vector2.zero;
            isReturning = false;
        }
    }

    void StartReturning()
    {
        isReturning = true;
    }

    // Detecta al jugador cuando entra en el área de activación
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CharacterPlayable"))
        {
            isTriggered = true;
        }
    }

    // Detecta cuando el jugador sale del área de activación
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CharacterPlayable"))
        {
            isTriggered = false;
        }
    }
}
*/