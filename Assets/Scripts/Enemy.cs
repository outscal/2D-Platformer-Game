using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f; // Adjust this to set the speed of the enemy
    public Transform leftPoint; // Set the leftmost point
    public Transform rightPoint; // Set the rightmost point

    private bool movingRight = true;

    void Update()
    {
        // Move the enemy left or right
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            // Check if the enemy reached the right point, then turn left
            if (transform.position.x > rightPoint.position.x)
            {
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            // Check if the enemy reached the left point, then turn right
            if (transform.position.x < leftPoint.position.x)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        // Change the direction the enemy is facing
        movingRight = !movingRight;

        // Flip the enemy's sprite by scaling it
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
