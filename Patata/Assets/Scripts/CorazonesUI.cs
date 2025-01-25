using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Linq;
public class NewBehaviourScript : MonoBehaviour
{

    public GameObject CorazonPrefab;
    private PlayerStadistics playerStadistics;

    private void DesactivarVida(int indice)
    {
        playerStadistics = FindObjectOfType<PlayerStadistics>();
    }



}
