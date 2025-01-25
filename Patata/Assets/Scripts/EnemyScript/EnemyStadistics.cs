using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStadistics : MonoBehaviour
{

    public int life;
    public int damageTaken;
    public int damage;
    public float enemyMoveSpeed=2f;
    public float enemyMoveSpeedFly=0.3f;

    public int enemyType;
    // Start is called before the first frame update
    
    public void takeDamage()
    {
        life=life-damageTaken;
    }

    public void FixedUpdate()
    {
        if(life<=0)
        {
            Destroy(gameObject);
        }
    }


}
