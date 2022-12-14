using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform[] endPositions;
    private Transform nextPosition;
    private int nextPositionIndex;
    public float enemySpeed; 
    public bool moveRight;

    private void Start()
    {
        nextPosition = endPositions[0];
    }

    private void Update()
    {
        EnemyMovement();
        enemyFlip();
    }

    private void EnemyMovement()
    {
        if(transform.position == nextPosition.position)
        {
            nextPositionIndex++;
            if (nextPositionIndex >= endPositions.Length)
            {
                nextPositionIndex = 0;
            }
            nextPosition = endPositions[nextPositionIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition.position, enemySpeed * Time.deltaTime);
        }
    }

    private void enemyFlip()
    {
        if(moveRight)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(-1*transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Turn"))
        {
            if(moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
    }
}
