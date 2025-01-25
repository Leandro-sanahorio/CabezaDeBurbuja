using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStadistics : MonoBehaviour
{

    public int runSpeedPlayer = 55;

    public float jumpSpeedPlayer = 5f;

    private CheckG checkG;

    public int life;

    public int maximunLife;



    Rigidbody2D rigitBodyCharacter;


    private void Start()
    {
        rigitBodyCharacter = GetComponent<Rigidbody2D>();
        checkG= FindObjectOfType<CheckG>();
    }


    void FixedUpdate()
    {
        if (Input.GetKey("a"))                                                                                  // SI PRESIONO A
        {
            rigitBodyCharacter.velocity = (new Vector2(-runSpeedPlayer* Time.deltaTime, rigitBodyCharacter.velocity.y)); // movimiento
            gameObject.GetComponent<SpriteRenderer>().flipX = true;                   // voltear animacion
            gameObject.GetComponent<Animator>().SetBool("Run", true);                  // cambiar animacion 
        }

        else if (Input.GetKey("d"))                                                                             // SI PRESIONO D
        {
            rigitBodyCharacter.velocity = (new Vector2(runSpeedPlayer* Time.deltaTime, rigitBodyCharacter.velocity.y));                 
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<Animator>().SetBool("Run", true);
        }

        else                                                                                                   // SI NO PRESIONO 
        {         
            rigitBodyCharacter.velocity = (new Vector2(0, rigitBodyCharacter.velocity.y));                       // movimiento 0
            gameObject.GetComponent<Animator>().SetBool("Run", false);               // animacion idle
        }

        if (Input.GetKey("w") && CheckG.isg || Input.GetKey("space") && CheckG.isg)                           // SALTO         
        {
            rigitBodyCharacter.velocity = new Vector2(rigitBodyCharacter.velocity.x, jumpSpeedPlayer);
            
        }
        
        if (CheckG.isg == false)                                                                               // EN EL AIRE
        {
            gameObject.GetComponent<Animator>().SetBool("jump", true);
            gameObject.GetComponent<Animator>().SetBool("Run", false);                 // animacion en el aire
            
        }
        if (CheckG.isg == true)                       //SI ESTOY EN EL SUELO
        {
            gameObject.GetComponent<Animator>().SetBool("jump", false);
        }
    }

    public void HealthLife(int healthLife)
    {
        life=life+healthLife;
        if (life+healthLife>maximunLife)
        {
            life=maximunLife;
        }
    }

}    

 


    