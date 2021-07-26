using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    
    public float speed;
    public GameObject EnemyCollisionWall1;
    PlayerController playerController;

    bool isEnemyGoingRight=true;

    
    void Update()
    {
        EnemeyWalk(isEnemyGoingRight);
        FlipKarege(isEnemyGoingRight);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "EnemyCollisionWall1")
        {
            print("Enemy is colliding with" + collision.gameObject.name);
            EnemeyWalk(false);

        }
        else if (collision.gameObject.tag == "EnemyCollisionWall2")
        {
            print("Enemy is colliding with" + collision.gameObject.name);
            EnemeyWalk(true);

        }
        else if(collision.gameObject.GetComponent<PlayerController>())
        {
            playerController = collision.gameObject.GetComponent<PlayerController>();

            playerController.KillPlayer();
        }
    }

    private void EnemeyWalk(bool isRight)
    {
        Vector3 position = transform.localPosition;
        if (isRight)
        { 
            position.x = position.x + (speed * Time.deltaTime);
            FlipKarege(isRight);
            isEnemyGoingRight = true;
        }
        else
        {
            position.x = position.x + -1f*(speed * Time.deltaTime);
            FlipKarege(isRight);
            isEnemyGoingRight = false;
        }
        transform.localPosition = position;
    }

    private void FlipKarege(bool isRight)
    {
        Quaternion rotation = transform.localRotation;
        if (isRight)
        {
            rotation.y = 0;
        }
        else
        {
            rotation.y = 180;
        }
        transform.localRotation = rotation;
      
    }
}
