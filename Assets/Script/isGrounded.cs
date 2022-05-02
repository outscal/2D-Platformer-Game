using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    public bool isOnGrounded = false;
   private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "floor")
        {
             isOnGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isOnGrounded = false;
    }
}
