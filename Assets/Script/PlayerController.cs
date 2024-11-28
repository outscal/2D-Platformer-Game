using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCol;

    //Collider Variables
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;

    public float speed;
    public float jumpForce;
    public bool isGrounded = false;
    public Rigidbody2D rigidbody2D;

    private void Start()
    {
        //Fetching initial collider properties
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;

        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxisRaw("Jump");
        float vertical = Input.GetAxisRaw("Jump");
        PlayerMovementAnimation(horizontal, vertical);
        PlayerMovement(horizontal, vertical);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }

    }

    private void PlayerMovement(float horizontal, float vertical)
    {
        Vector2 pos = transform.position;
        pos.x += speed * horizontal * Time.deltaTime;

        transform.position = pos;

        if (vertical > 0 && isGrounded)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
        }

    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector2 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }

        if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (vertical > 0 && isGrounded)
        {
            playerAnimator.SetBool("Jump", true);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
        }
    }

    public void Crouch(bool crouch)
    {
        if (crouch == true)
        {
            float offX = -0.12494f;     //Offset X
            float offY = 0.61027f;      //Offset Y

            float sizeX = 0.8923f;     //Size X
            float sizeY = 1.3452f;     //Size Y

            boxCol.size = new Vector2(sizeX, sizeY);   //Setting the size of collider
            boxCol.offset = new Vector2(offX, offY);   //Setting the offset of collider
        }

        else
        {
            //Reset collider to initial values
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }

        //Play Crouch animation
        playerAnimator.SetBool("Crouch", crouch);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "platform")
        {
            isGrounded = false;
        }
    }
}
