using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverController : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.gameObject.GetComponent<PlayerController>() != null )
       {
           //Level is over
           Debug.Log("Level Finished by the Player");
           Debug.Log(" Loading the next level");
       }
   }
}