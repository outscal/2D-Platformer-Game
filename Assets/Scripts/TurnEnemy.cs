using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEnemy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Turn= true");
        if (collision.gameObject.GetComponent<EnemyController>() != null)
        {
            EnemyController enemycontroller = collision.gameObject.GetComponent<EnemyController>();
            Debug.Log(enemycontroller);
            Debug.Log("Turn= true");
            enemycontroller.turnenemy = true;  
        }
    }
   
}
