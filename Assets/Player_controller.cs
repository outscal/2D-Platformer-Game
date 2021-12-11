using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Animator animator;
    
    public float speed;
    public float jump;


    private Rigidbody2D rigi2D;
    private void Awake()
    {
        Debug.Log(" player controller awake ");
        rigi2D = gameObject.GetComponent<Rigidbody2D>();
      // rigi2D = GetComponent<Animator>();
    }

    private void Update()
    {      // for moving character horizontally

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);

        // for moving character vertically

        if (vertical > 0)
        {
            rigi2D.AddForce(new Vector2(0f , jump), ForceMode2D.Force);

        }

    }
    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        // (distance / time(sec)) * ( 1/ 30 sec)
        
        //a = a+b
        // can be writen as a+=b
        position.x += horizontal * speed * Time.deltaTime;                        // for movement of the chearctor
        transform.position = position;
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);                          
        }

        else if (horizontal > 0)
        {

            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

         // for jumping
        

        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {  
            animator.SetBool("Jump", false);           
        }

        //Input.GetKeyDown(KeyCode.RightControl );

        if (animator == true && Input.GetKey(KeyCode.Z))
        {
            animator.SetTrigger("takeof");
            
            
        }





    }
}       
