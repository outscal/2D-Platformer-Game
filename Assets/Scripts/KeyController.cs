using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.GetComponent<PlayerControllerScript>() != null)
        {
            PlayerControllerScript player = other.gameObject.GetComponent<PlayerControllerScript>();
            player.PickKey();
            Destroy(gameObject);    
        }
    }
}
