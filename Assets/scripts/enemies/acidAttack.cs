using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acidAttack : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.GetComponent<playerController>() != null && collision.gameObject.CompareTag("Player"))
        {
            playerController pc;

            pc = collision.gameObject.GetComponent<playerController>();


            pc.looseHealth();


            Destroy(gameObject, 2);
        }
    }
}