using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cam;
    public float offset = -90;
    public float speed;
    public float CD = 10;

    public GameObject Proyectile;
    public Transform shootP;

    private void Update()
    {
        Vector3 diference = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rtZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rtZ + offset);

        if (Input.GetButtonDown("Fire1"))                                                               // SI PRECIONO CLICK
        {
            GameObject THMK = Instantiate(Proyectile, shootP.position, shootP.rotation);
            Rigidbody2D rb = THMK.GetComponent<Rigidbody2D>();
            rb.AddForce(shootP.up * speed, ForceMode2D.Impulse);


        }
    }
}
