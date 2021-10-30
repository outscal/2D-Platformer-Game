using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    int speed = 2;
    public float  patrollingDistance;
    public Transform groundDection;   
     
    playerController pc;
    Animator anmi;
   float distance;
    Vector3 position;
    void Start()
    {

        anmi = gameObject.GetComponent < Animator >();
        position = transform.position;

    }
    private void Update()
    {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);

        move();
        raycastMove();
    }

   
    

    private void move()
    {
        distance = Mathf.Abs(position.x - transform.position.x);
        if ( patrollingDistance < distance)
            changeDrirection();               
            }
    void raycastMove()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDection.position, Vector2.down, 2);
        if (groundInfo.collider == false)
            changeDrirection();
    }
   

    
    private void changeDrirection()
    {
       
        transform.Translate(new Vector3( -1, 0, 0) );
        transform.Rotate(new Vector3(0, 180 , 0));

    }





private void OnCollisionEnter2D(Collision2D collision)
{

        

        if (collision.gameObject.GetComponent<playerController>() != null && collision.gameObject.CompareTag("Player"))
        {
           pc = collision.gameObject.GetComponent<playerController>();          
            
           changeDrirection();
            pc.looseHealth();
            anmi.SetBool("attack", true);
            //collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction*10, 2), ForceMode2D.Impulse);
            StartCoroutine (Attack(1));
           


        }
    }

    
 
 IEnumerator Attack(int secs)
    {
        yield return new WaitForSeconds(secs);
       
        anmi.SetBool("attack", false);

    }



}
