using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDeath : MonoBehaviour
{
   
 private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<PlayerController>()!= null)
        {
            PlayerController playerController = col.gameObject.GetComponent<PlayerController>();

           playerController.FallingDown();
           
        }
    }
   
    
}
