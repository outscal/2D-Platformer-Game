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
    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
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

    private void OnCollisionEnter(Collision collision)
    {
       
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("enemyTarget") && collision.transform.parent.position==transform.parent.position)
        {
            direction *= -1;
            flip = !flip;
        }

        if (collision.gameObject.GetComponent<playerController>() != null)
        {
            playerController pc = collision.gameObject.GetComponent<playerController>();
            pc.LoosePlayerLIfe();

        }
    }



}
