//using System;
//using System.Collections;
//using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rigiBody2D;
    private void Awake()
    {
        rigiBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if(IsFacingRight())
        {
            rigiBody2D.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rigiBody2D.velocity = new Vector2(-moveSpeed, 0f);

        }
    }

    bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FlipEnemy();
    }

    private void FlipEnemy()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigiBody2D.velocity.x)), 1f);
    }
}
