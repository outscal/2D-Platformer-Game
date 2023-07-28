using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Destroy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player_Controller playerController = collision.gameObject.GetComponent<Player_Controller>();

        if(playerController != null)
        {

            playerController.playerDeath();    
           
        }
    }

    
}
