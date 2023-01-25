using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        PlayerMovementAnimation(horizontal);
        MoveCharacter(horizontal);

        
        float verticalInput = Input.GetAxis("Vertical");
        Jump(verticalInput);
        

        if(Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }


    }

    void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    void PlayerMovementAnimation(float horizontal)
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

    }

    public void Crouch(bool crouch)
    {
        animator.SetBool("Crouch", crouch);
    }    

    public void Jump(float verticalInput)
    {
        if(verticalInput > 0)
        {
            animator.SetTrigger("Jump");
        }
    }
}
