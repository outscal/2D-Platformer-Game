using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    //bool Crouch = false;
     
    private void Awake()
    {
    Debug.Log("Player controller awake");    
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //  Debug.Log("Collision:" + collision.gameObject.name);  
    // }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.LeftControl))
        // {
        //     Crouch = !Crouch;
        //     animator.SetBool("Crouch", Crouch);
        // }

         if(Input.GetKeyDown(KeyCode.LeftControl))
         {
           animator.SetBool("Crouch",true);  
         }

         if(Input.GetKeyUp(KeyCode.LeftControl))
         {
           animator.SetBool("Crouch",false);  
         }




        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        PlayMovementAnimation(horizontal);
        MoveCharacter(horizontal);



        
        
    }

    private void MoveCharacter(float horizontal)
    {
      Vector3 position = transform.position;
      position.x = position.x + horizontal * speed * Time.deltaTime;
      transform.position = position;
    }

    private void PlayMovementAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
         Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f* Mathf.Abs(scale.x);
            //scale.x=-1;
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            //scale.x = 1;
        }
        transform.localScale = scale;
    }
}
