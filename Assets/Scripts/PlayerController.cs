using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private Rigidbody2D rigidbody;
    public float jumpForce;
    public bool isGrounded;

    private void Awake()
    {
       rigidbody= gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        PlayerMovementAnimation(horizontal,vertical);
        MoveCharacter(horizontal,vertical);

        
        
        
        

        //if(Input.GetKey(KeyCode.LeftControl))
        //{
        //    Crouch(true);
        //}
        //else
        //{
        //    Crouch(false);
        //}


    }

    void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        if(vertical > 0)
        {
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
        }
    }

    void PlayerMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {

            scale.x = -1f;
        }
        else if (horizontal > 0)
    {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump
        if (vertical > 0 && isGrounded)
        {
            animator.SetBool("Jump", true);
           // rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

    }

   

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Platform"))
        {
            isGrounded= true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }




}

