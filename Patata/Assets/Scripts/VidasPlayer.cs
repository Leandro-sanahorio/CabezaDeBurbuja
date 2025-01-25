using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasPlayer : MonoBehaviour
{

    public int vidaActual;

    public int vidaMaxima;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void Tomardaño(int cantidadDaño)
    {
        int vidaTemporal = vidaActual - cantidadDaño;

        if (vidaTemporal < 0)
        {
            vidaActual = 0;

        }
        else
        {
            vidaActual = vidaTemporal;
                }
        if(vidaActual <= 0){
            Destroy(gameObject);
        }


    }
    public void CurarVida(int cantidadcuracion)
    {
        int vidaTemporal = vidaActual + cantidadcuracion;

        if (vidaTemporal > vidaMaxima) {
            vidaActual = vidaMaxima;

        }
        else
        {
            vidaActual = vidaTemporal;
        }
    }
    


    // Update is called once per frame
    void Update()
    {
        
    }
}
