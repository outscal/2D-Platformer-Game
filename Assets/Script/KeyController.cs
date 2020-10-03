using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.GetComponent<PlayerControl>() != null)
        {
            PlayerControl playerControl = collisionInfo.gameObject.GetComponent<PlayerControl>();
            playerControl.pickUpKey();
            Destroy(gameObject);
        }
    }

}
