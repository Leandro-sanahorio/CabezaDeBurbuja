using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeshot : MonoBehaviour
{
    public float lifetime;
    private EnemyStadistics enemyStadistics;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Enemy"))
        {
            enemyStadistics.takeDamage();
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
        enemyStadistics= FindObjectOfType<EnemyStadistics>();
    }



}

