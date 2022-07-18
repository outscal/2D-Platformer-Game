/*
 * For if Future Reference
 * 
 * Video- link 
 * https://www.youtube.com/watch?v=BlalhxSTUWo&t=203s
 * 
 * TRY with very low no. of sprite images, max=2 to render simplistic animations
 * for running this script
 */

using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 5f;
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 700f);

        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            anim.SetFloat("Speed", Mathf.Abs(dirX));
        else
            anim.SetFloat("Speed", 0);

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumpPressed", false);
            anim.SetBool("isFalling", false);
        }

        if (rb.velocity.y > 0)
            anim.SetBool("isJumpPressed", true);

        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumpPressed", false);
            anim.SetBool("isFalling", true);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    private void LateUpdate()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;


        if ((facingRight && localScale.x < 0) || (!facingRight && localScale.x > 0))
            localScale.x *= -1;

        transform.localScale = localScale;
    }
}