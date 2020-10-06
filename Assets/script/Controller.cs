using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.GetComponent<PlayerControll>()!=null){
            PlayerControll playerControll=collision.gameObject.GetComponent<PlayerControll>();
            playerControll.KillPlayer();
           
             }
         }
  
}
