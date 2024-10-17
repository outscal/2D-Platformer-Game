using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f; // Speed of the enemy
    public float leftBoundary = -5f; // Left boundary
    public float rightBoundary = 5f; // Right boundary

    private bool movingRight = true; // Direction flag

    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        // Move the enemy
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            // Check if the enemy has reached the right boundary
            if (transform.position.x >= rightBoundary)
            {
                movingRight = false; // Change direction to left
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            // Check if the enemy has reached the left boundary
            if (transform.position.x <= leftBoundary)
            {
                movingRight = true; // Change direction to right
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
            
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy hit the boundary
        if (other.CompareTag("Boundary"))
        {
            // Reverse direction if hitting a boundary
            movingRight = !movingRight;
        }
    }
}
