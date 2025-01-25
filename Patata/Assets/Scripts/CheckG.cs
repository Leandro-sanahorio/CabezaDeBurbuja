using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckG : MonoBehaviour
{
    public static bool isg;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            isg = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isg = false;
    }
}
