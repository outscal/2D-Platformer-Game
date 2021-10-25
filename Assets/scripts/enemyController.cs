using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    int speed = 2;
    public int patrollingDistance;
    public Transform groundDection;
   
    int direction = 1;
   
    playerController pc;
    Animator anmi;
    Vector3 distance;
    Vector3 position;
    private void Start()
    {

        anmi = gameObject.GetComponent < Animator >();
        position = gameObject.transform.position;

    }
    private void Update()
    {
        move();
    }

    private void move()
    {
        DistanceCheck();
        transform.position += Vector3.right * direction * Time.deltaTime*speed;        
       RaycastHit2D groundInfo = Physics2D.Raycast(groundDection.position, Vector2.down, 2);
        if (groundInfo.collider == false)
            changeDrirection();

    }
    private void DistanceCheck()
    {
        
        distance.x =(int) Mathf.Abs(position.x - transform.position.x);
        if (distance.x > patrollingDistance)
            changeDrirection();
    }

    
    private void changeDrirection()
    {
        direction *= -1;
        transform.rotation =  Quaternion.Euler (new Vector3(0, 90 + (-direction * 90), 0));
       
    }

    
  

    private void OnTriggerEnter2D(Collider2D collision)
    {

        

        if (collision.gameObject.GetComponent<playerController>() != null && collision.gameObject.CompareTag("Player"))
        {
           pc = collision.gameObject.GetComponent<playerController>();          
            
           changeDrirection();
            anmi.SetBool("attack", true);
            collision.transform.position -= new Vector3(2, -2);
            
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-4, 2), ForceMode2D.Impulse);
            StartCoroutine (Attack(1));
           

        }
    }

    
 
 IEnumerator Attack(int secs)
    {
        yield return new WaitForSeconds(secs);
        pc.looseHealth();
        anmi.SetBool("attack", false);

    }



}
