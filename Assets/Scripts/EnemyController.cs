using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;
    public Transform leftEdge;
    public Transform rightEdge;
    public Transform enemy;
    private bool movingLeft;
    private Vector3 initialScale;

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        if(movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else 
            {
                DirectionChange();
            }   
        }
        else
        {
            if(enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                //change direction
                DirectionChange();
            }
        }
    }

    //To change the direction of enemy
    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            //playerController.KillPlayer();
        }
    }

    private void MoveInDirection(int direction)
    {
        enemy.position = new Vector3(enemy.position.x + enemySpeed * direction * Time.deltaTime, enemy.position.y, enemy.position.z);
        enemy.localScale = new Vector3(Mathf.Abs(initialScale.x) * direction, initialScale.y, initialScale.z);
    }
}
