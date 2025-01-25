using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayer : MonoBehaviour
{

    public int runSpeed = 55;

    public float jumpSpeed = 5f;

    Rigidbody2D rb2d;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (Input.GetKey("a"))                                                                                  // SI PRECIONO A
        {
            rb2d.velocity = (new Vector2(-runSpeed* Time.deltaTime, rb2d.velocity.y)); // movimiento
            gameObject.GetComponent<SpriteRenderer>().flipX = false;                   // voltear animacion
            gameObject.GetComponent<Animator>().SetBool("Run", true);                  // cambiar animacion 
        }

        else if (Input.GetKey("d"))                                                                             // SI PRECIONO D
        {
            rb2d.velocity = (new Vector2(runSpeed* Time.deltaTime, rb2d.velocity.y));                 
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<Animator>().SetBool("Run", true);
        }

        else                                                                                                   // SI NO PRECIONO 
        {         
            rb2d.velocity = (new Vector2(0, rb2d.velocity.y));                       // movimiento 0
            gameObject.GetComponent<Animator>().SetBool("Run", false);               // animacion idle
        }

        if (Input.GetKey("w") && CheckG.isg || Input.GetKey("space") && CheckG.isg)                           // SALTO         
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
        
        if (CheckG.isg == false)                                                                               // EN EL AIRE
        {
            gameObject.GetComponent<Animator>().SetBool("Run", false);                 // animacion en el aire
        }

    }




}    

 


    