using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private float speed = 7f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundlayer;



    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        flip();

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
