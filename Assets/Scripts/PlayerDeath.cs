using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private int PHealth;
   // public PlayerController playercontroller;
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
  
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            anim.SetBool("isDead", true);
            Debug.Log("player died");       
        }
     }
    

}
    
