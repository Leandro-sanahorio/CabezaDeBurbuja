using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeshot : MonoBehaviour
{
    public float lifetime;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

}

