using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
public class NewBehaviourScript : MonoBehaviour
{

    public List<Image> listaCorazones;
    public GameObject CorazonPrefab;
    public VidasPlayer VidasPlayer;

    public int indexActual;

    public Sprite bordecorazon;
    public Sprite corazon;

    private void Awake()
    {
        VidasPlayer.cambioVida.AddListener(CambiarCorazones);
         
    }
    private void CambiarCorazones(int vidaActual)
    {
        if (!listaCorazones.Any())
        {
            CrearCorazones(vidaActual);
        }
        else
        {
            CambiarVida(vidaActual);
        }
    }

    private void CambiarVida()
    {
        
    }

    private void CrearCorazones()
    {
        for (int i = 0)
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
