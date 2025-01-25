using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeshot : MonoBehaviour
{
    public float lifetime;
    private EnemyStadistics enemyStadistics;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.collider.CompareTag("Enemy"))
        {
            enemyStadistics.takeDamage();
        }
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
        enemyStadistics= FindObjectOfType<EnemyStadistics>();
    }



}

