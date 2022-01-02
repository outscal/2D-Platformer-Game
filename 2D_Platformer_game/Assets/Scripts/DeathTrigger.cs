using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathTrigger : MonoBehaviour
{
    public GameOverController gameOverController;
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
         gameOverController.Playerdied();
           
           
        }
    }
}
