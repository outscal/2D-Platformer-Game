using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallinngdown : MonoBehaviour
{
    public bool IsAlive =true;

    public Animator animator;

    

   private void OnTriggerEnter2D(Collider2D collision) 
   {
        if(collision.gameObject.GetComponent<PlayerControllerScript>() != null)
        {
            PlayerControllerScript player =collision.gameObject.GetComponent<PlayerControllerScript>();
            player.KillPlayer();
        }
   }
   private void Update() 
    {
        animator.SetBool("IsAlive",IsAlive);
    }
}
