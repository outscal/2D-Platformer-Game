using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float patrolDistance = 5f;  // Distance the enemy will move from its starting position
    public float speed = 2f;           // Speed of the enemy

    private Vector3 startingPosition;   // The original position of the enemy
    public int direction = 1;          // Moving direction: 1 for right, -1 for left

    private void Start()
    {
        startingPosition = transform.position;  // Save the starting position
    }

    private void Update()
    {
        // Move the enemy
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        // Check if the enemy has reached the patrol distance
        float distanceFromStart = Vector3.Distance(transform.position, startingPosition);

        if (distanceFromStart >= patrolDistance)
        {
            direction *= -1;  // Reverse the direction
            FlipSprite();
            startingPosition = transform.position;  // Update the starting position to where it turned
        }
    }
    private void FlipSprite()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;   // Invert the X scale to flip the sprite
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            collision.gameObject.GetComponent<PlayerController>().KillPlayer();
        }
    }


}
