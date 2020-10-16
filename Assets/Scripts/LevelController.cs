using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level is completed");
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            playerController.level += 1;
            playerController.LoadAnyLevel(playerController.level);

        }
    }
}
