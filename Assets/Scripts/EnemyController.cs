using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";

    Rigidbody2D rb2d;
    Vector3 baseScale;
    string facingDirection;

    [SerializeField] Transform castPos;
    public float castDist = 0.5f;
    public float moveSpeed = 5f;
    

    private void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
        baseScale = transform.localScale;   // base scale would be same as the scale at the start of game, later can to change it
        facingDirection = RIGHT;   // by default, enemy has move to the right
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            Debug.Log("Enemy has Killed the Player");
            //playerController.KillPlayer();
        }
    }

    private void FixedUpdate()
    {
        float vX = moveSpeed;
        if(facingDirection == LEFT)
        {
            vX = -moveSpeed;
        }

        rb2d.velocity = new Vector2(vX, rb2d.velocity.y);

        if(IsNearEdge() || IsHittingWall())
        {
            if(facingDirection == LEFT)
            {
                ChangeFacingDirection(RIGHT);
            }
            else if (facingDirection == RIGHT)
            {
                ChangeFacingDirection(LEFT);
            }
        }
    }

    bool IsNearEdge()
    {
        bool val = true;

        Vector2 targetPos = castPos.position; // setting the target position for the linecast
        targetPos.y -= castDist; // setting the end point for the linecast end point

        Debug.DrawLine(castPos.position, targetPos, Color.red); // Drawing line in Scene view

        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Platform")))
        {
            val = false;
        } 
        else
        {
            val = true;
        }

        return val;
    }

    bool IsHittingWall()
    {
        bool val = false;
        
        Vector2 targetPos = castPos.position;
        //targetPos.x += castDist;
        if(facingDirection == RIGHT)
        {
            targetPos.x += castDist;
        } else if(facingDirection == LEFT)
        {
            targetPos.x -= castDist;
        }

        Debug.DrawLine(castPos.position, targetPos, Color.green);

        if(Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Platform")))
        {
            val = true;
        }
        else
        {
            val = false;
        }

        return val;
    }

    void ChangeFacingDirection(string newDirection)
    {
        // Function to change the facing direction of enemy once it either reaches wall / end of platform
        Vector3 newScale = baseScale;
        if(newDirection == LEFT)
        {
            newScale.x = -baseScale.x;
        } else if(newDirection == RIGHT)
        {
            newScale.x = baseScale.x;
        }

        transform.localScale = newScale;

        facingDirection= newDirection;
    }

}
