using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{

    public int healthAmount;
    private PlayerStadistics playerStadistics;
    private void Start()
    {
        playerStadistics= FindObjectOfType<PlayerStadistics>();
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStadistics.HealthLife(healthAmount);
        }
        Destroy(gameObject);
    }
}
