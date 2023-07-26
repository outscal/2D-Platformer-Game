using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Manager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            
            Player_Controller playerController = collision.gameObject.GetComponent<Player_Controller>();
            playerController.PickKey();
            Destroy(gameObject);

        }
    }
}
