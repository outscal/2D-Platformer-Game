using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator enemyAnimator;
    
    public float speed;

    public float RayDistance;

    public bool ismovingRight;

    public Transform groundDetection;

    public LivesController livesController;
     
    
    //when a player collide with an enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            livesController.LoseLife(); 
        }
    }

    // flip the enemy when it reaches the boundary of its patrol path
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided"); 

        if(collision.gameObject.CompareTag("boundary"))
        {
            speed *= -1; 
        }
    }

    private void changeEnemyDir()
    {
        if (speed > 0)
        {
            ismovingRight = true; 
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            ismovingRight = false; 
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //changeEnemyDir(); 

        //RaycastHit2D GroundDetector = Physics2D.Raycast(groundDetection.position, Vector2.down, RayDistance);

        //if (!GroundDetector.collider)
        //{
        //    if (ismovingRight)
        //    {
        //        transform.eulerAngles = new Vector3(0, -180, 0);
        //        ismovingRight = false;
        //    }
        //    else
        //    {
        //        transform.eulerAngles = new Vector3(0, 0, 0);
        //        ismovingRight = true;
        //    }

        //}

    }
}
