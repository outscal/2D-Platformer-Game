using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
[SerializeField] private Animator animator;
[SerializeField] private float Speed = 0f;
[SerializeField] private float jump = 0f;
private Rigidbody2D rb;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        float vert = Input.GetAxisRaw("Vertical");
        float horiz = Input.GetAxisRaw("Horizontal");

        PlayerMove(horiz, vert);
        PlayerMoveAnim(horiz, vert);

        //for crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }

    }

    private void PlayerMove(float horiz, float vert)
    {
        Vector3 position = transform.position;

        position.x = position.x + (horiz * Speed * Time.deltaTime);
        transform.position = position;

        //for jump
        if(vert >0)
        {
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }

    private void PlayerMoveAnim(float horiz, float vert)
    {
        animator.SetFloat("Speed", Mathf.Abs(horiz));
        Vector3 scale = transform.localScale;


        if (horiz < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horiz > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        //for Jump
        if (vert > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        transform.localScale = scale;
    }
}