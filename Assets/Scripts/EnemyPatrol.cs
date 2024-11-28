using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Vector3 pointA;  // The first patrol point
    public Vector3 pointB;  // The second patrol point
    public float patrolSpeed = 2f;  // Speed at which the enemy moves
    private bool movingToB = true;  // Determines if the enemy is moving towards point B
    private bool isFacingRight = true; // Tracks which way the enemy is facing

    

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (movingToB)
        {
            // Move towards point B
            transform.position = Vector3.MoveTowards(transform.position, pointB, patrolSpeed * Time.deltaTime);

            // Flip direction if needed
            if (!isFacingRight)
            {
                Flip();
            }

            // If the enemy reaches point B, change direction
            if (Vector3.Distance(transform.position, pointB) < 0.1f)
            {
                movingToB = false;
            }
        }
        else
        {
            // Move towards point A
            transform.position = Vector3.MoveTowards(transform.position, pointA, patrolSpeed * Time.deltaTime);

            // Flip direction if needed
            if (isFacingRight)
            {
                Flip();
            }

            // If the enemy reaches point A, change direction
            if (Vector3.Distance(transform.position, pointA) < 0.1f)
            {
                movingToB = true;
            }
        }
    }

    void Flip()
    {
        // Invert the facing direction
        isFacingRight = !isFacingRight;

        // Multiply the enemy's x scale by -1 to flip the sprite
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
