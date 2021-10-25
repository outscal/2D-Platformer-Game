using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    int speed = 2;
    bool  flip=false;
    int direction = 1;
    SpriteRenderer sr;
    playerController pc;
    Animator anmi;
    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        anmi = gameObject.GetComponent < Animator >();
    }
    private void Update()
    {
        move();
    }

    private void move()
    {
        transform.position += Vector3.right * direction * Time.deltaTime*speed;
        sr.flipX = flip;
    }

    private void changeDrirection()
    {
        direction *= -1;
        flip = !flip;
    }

    
  

    private void OnTriggerEnter2D(Collider2D collision)
    {

         if (collision.gameObject.CompareTag("enemyTarget") && collision.transform.parent.position==transform.parent.position)
        {
            changeDrirection();
        }

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
        anmi.SetBool("attack",false);

    }



}
