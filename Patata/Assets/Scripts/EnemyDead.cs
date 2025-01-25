/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDead: MonoBehaviour
{
    public Slider enemyHealthBar; // Slider used to keep track
    private EnemyHealth enemyHealth; // Reference to enemy health script where maxhealth and current are
    public bool enemyHurt; // how the game can tell if the enemy is being hit

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = FindObjectOfType<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.CurrentHealth < enemyHealth.MaxHealth) // if the enemy health is below its max health
        {
            enemyHurt = true;
        }

        if (!enemyHurt)
        {
            enemyHealthBar.gameObject.SetActive(false); // why doesn't this work to have the bar not shown when the enemy is not being hurt
        }

        if(enemyHurt)
        {
            enemyHealthBar.gameObject.SetActive(true); // why does this not work to only show the bar when the enemy is hurt
            enemyHealthBar.maxValue = enemyHealth.MaxHealth;
            enemyHealthBar.value = enemyHealth.CurrentHealth;
        }
    }
}*/