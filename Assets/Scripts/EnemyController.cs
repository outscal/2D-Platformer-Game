using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speedy;
    public float rayDist;
    private bool movingRight;
    bool attack;
    public Transform groundDetect;
    Animator animator;


    [SerializeField] private int enemyDamage;
    [SerializeField] private HeartSystem _heartSystem;
    
    private void Update()
    {
        transform.Translate(Vector2.right * speedy * Time.deltaTime);
        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayDist);
        
        if(groundCheck.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
       if (collision.gameObject.GetComponent<PlayerController>() != null)
         {
           PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
      ///  playerController.KillPlayer();
           Damage();
         }
    }

    private void Damage()
    {
        _heartSystem.playerHealth -= enemyDamage; 
        _heartSystem.UpdateHealth();
    //Needs to Disable Enemy
   // gameObject.SetActive(true);
    }
}
