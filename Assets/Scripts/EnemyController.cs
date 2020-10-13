using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    PlayerController playerController;


    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision " + collision.gameObject.name);
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();

        }

    }


}
