using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Camera cam;
    public float offset = -90;
    public float speed;
    public float CD = 10;

    public int containerBullets;
    public float timeRecharger=0;

    public GameObject Proyectile;
    public Transform shootP;

    private void Update()
    {
        //Seguimiento del raton
        Vector3 diference = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rtZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rtZ + offset);
        Shoot();
        //Se trabajara a futuro un cambio de arma

    }

    private void Shoot()
    {
         // SI PRESIONO CLICK Y MI CONTADOR NO ES =>5      
        if (Input.GetButtonDown("Fire1")&& containerBullets<=4)                                                               
        {
            GameObject bulletGameObject = Instantiate(Proyectile, shootP.position, shootP.rotation);
            Rigidbody2D rigitBodyBulletGameObject = bulletGameObject.GetComponent<Rigidbody2D>();
            rigitBodyBulletGameObject.AddForce(shootP.up * speed, ForceMode2D.Impulse);
            containerBullets++;
        //Volver al final (Optimizar) :v
        }else if(containerBullets>4){
            TimeRecharger();
        }
    }

    private void TimeRecharger()
    {
        timeRecharger+=Time.deltaTime;
            if(timeRecharger>=3){
                containerBullets=0;
                timeRecharger=0;
            }
    }


}
