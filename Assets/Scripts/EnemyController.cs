using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] LayerMask platformLayerMask;
    [SerializeField] Transform endPos;
    [SerializeField] float moveSpeed;
    Rigidbody2D rigiBody2D;
    BoxCollider2D boxCollider2D;
    private void Awake()
    {
        rigiBody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if(FacingRight())
        {
            rigiBody2D.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rigiBody2D.velocity = new Vector2(-moveSpeed, 0f);
        }

        Flip();

    }

    private bool FacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void Flip()
    {
        if (!Physics2D.Raycast(endPos.position, Vector2.down, 0.5f, platformLayerMask))
        {
            Debug.Log("NOt colliding");
            transform.localScale = new Vector2(-(Mathf.Sign(rigiBody2D.velocity.x)), transform.localScale.y);
        }
        else
        {
            Debug.Log("Colliding");
        }
    }

    
}
