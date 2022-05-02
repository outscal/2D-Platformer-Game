using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Debug.Log("Player Colling");
           PlayerController playerController = (PlayerController)collision.gameObject.GetComponent<PlayerController>();
            playerController.playerDeathAnimation();
            
        }
    }
}
