using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEnemy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() != null)
        {
            EnemyController enemycontroller = collision.gameObject.GetComponent<EnemyController>();
            Debug.Log(enemycontroller);
            enemycontroller.turn();
            Destroy(gameObject);
        }
    }
   
}
