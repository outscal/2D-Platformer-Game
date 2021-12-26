using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
   
    public LayerMask gLM;
    public float Speed;

    private bool moveright = true;
    public Transform groundDetection;

    private void Update()
    {
        transform.Translate(Vector2.right*Speed*Time.deltaTime);
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position,Vector2.down,2f,gLM);
        if(groundinfo.collider == false)
        {
            if(moveright == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveright = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveright = true;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.DamagePlayer();
            //playerController.KillPlayer();
            
        }
    }
}       
