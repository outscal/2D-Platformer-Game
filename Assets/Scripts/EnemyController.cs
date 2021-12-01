using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
     private void OnTriggerEnter2D(Collider2D collision){
         if(collision.gameObject.GetComponent<PlayerController>()!=null){
             PlayerController playerController=collision.gameObject.GetComponent<PlayerController>();
             playerController.KillPlayer();
             
         }
     }
}
