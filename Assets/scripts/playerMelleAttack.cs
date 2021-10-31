using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMelleAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<enemyController>() != null)
        {
            
            enemyController ec;
            ec = other.GetComponent<enemyController>();
            ec.loseHealth();
        }
    }

   
   
   


}