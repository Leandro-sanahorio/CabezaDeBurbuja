using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] vidas;

    public void DesactivarVida(int indice){
        vidas[indice].SetActive(false);
    }

    public void ActivarVida(int indice){
        vidas[indice].SetActive(true);
    }
}
