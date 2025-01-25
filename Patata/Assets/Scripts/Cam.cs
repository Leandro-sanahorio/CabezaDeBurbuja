using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject follow;
    public Vector2 minCamp, maxCamp;

    public float size;

    void FixedUpdate()
    {

        float posx = follow.transform.position.x;
        float posy = follow.transform.position.y;
                                                                 //RESTRICCIONES EN CONRDENADAS 
        transform.position = new Vector3(
            Mathf.Clamp(posx, minCamp.x, maxCamp.x),
            Mathf.Clamp(posy, minCamp.y, maxCamp.y),
            transform.position.z);

    }
}
