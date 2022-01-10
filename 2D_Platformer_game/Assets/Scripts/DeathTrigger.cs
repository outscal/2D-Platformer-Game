using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathTrigger : MonoBehaviour
{
    private PlayerController playerController;
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
         playerController = collision.gameObject.GetComponent<PlayerController>();
         playerController.KillPlayer();

           
           
        }
    }
}
