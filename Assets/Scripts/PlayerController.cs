using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private void Awake()
    {
        Debug.Log("Player controller awake");
    }
    
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("Collision: " + collision.gameObject.name);
    // }

    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if(speed < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if(speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

    //     for jump animation 
    //    if(Input.GetButtonDown("Jump"))
    //    {
    //         float verticalSpeed = Input.GetAxisRaw("Vertical");
    //         animator.SetBool("Jump", true);

    //         Vector3 verticalPos = transform.position;
    //         if(verticalSpeed > 0)
    //         {
    //             verticalPos.y = Mathf.Abs(verticalPos.y);
    //         }
    //         transform.position = verticalPos;
    //    }
    //    else if (Input.GetButtonUp("Jump"))
    //    {
    //         animator.SetBool("Jump", false);
    //    }
    

    //another way for jump 
        float verticalSpeed = Input.GetAxisRaw("Vertical");

        Vector3 verticalPos = transform.position;
        if(verticalSpeed > 0)
        {
            animator.SetBool("Jump", true);
            verticalPos.y = Mathf.Abs(verticalPos.y);
        }  
        else if (verticalSpeed < 0 )
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Crouch", true);
        }
        transform.position = verticalPos;
        //animator.SetBool("Crouch", false);
    }
}
