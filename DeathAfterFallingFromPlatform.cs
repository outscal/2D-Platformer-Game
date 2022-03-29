using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAfterFallingFromPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.gameObject.GetComponent<PlayerController>() != null )
       {
           //Level is over
           
           Debug.Log("Player is Dead After Falling From Platform");
       }
   }
}
