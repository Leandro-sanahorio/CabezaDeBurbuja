using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
public class CorazonesUI : MonoBehaviour
{
    public GameObject[] vidas;
    public Image progressBar; // La imagen con "Fill"

    public void DesactivarVida(int indice){
        vidas[indice].SetActive(false);
    }

    public void ActivarVida(int indice){
        vidas[indice].SetActive(true);
    }

    //Stand by
    //private void UpdateProgressBar()
    //{
    //    if (progressBar != null)
    //    {
    //        progressBar.fillAmount  = (float)10 / 20; // Calcula el porcentaje
    //    }
    //}

}
