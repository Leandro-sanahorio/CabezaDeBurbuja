using UnityEngine;

public class PinchoAttack : MonoBehaviour
{
    public float altura = 3f; // Altura a la que subirán los pinchos
    public float velocidad = 1f; // Velocidad del movimiento
    private Vector3 posicionInicial;
    private bool subiendo = true;

    // Referencia al jugador
    private GameObject player;

    void Start()
    {
        // Guardamos la posición inicial de los pinchos
        posicionInicial = transform.position;

        // Encontramos el objeto del jugador
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Si el ataque está activo, movemos los pinchos
        if (subiendo)
        {
            // Subimos los pinchos
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, posicionInicial.y + altura, transform.position.z), velocidad * Time.deltaTime);

            // Si llegamos a la altura máxima, comenzamos a bajar
            if (transform.position.y >= posicionInicial.y + altura)
            {
                subiendo = false;
            }
        }
        else
        {
            // Bajamos los pinchos
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidad * Time.deltaTime);

            // Si llegamos a la posición inicial, paramos
            if (transform.position.y <= posicionInicial.y)
            {
                subiendo = true;
            }
        }
    }

    // Método que se activa cuando el pincho entra en contacto con el jugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si el objeto con el que colisiona tiene la etiqueta "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStadistics>().life -= 3;
        }
    }
}

