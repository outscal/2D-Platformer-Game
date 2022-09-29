using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public Animator animator;
    
    public bool jumpSpeed;
    [SerializeField]
    private float playerSpeed;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        MoveCharecter(horizontal);
        MovementAnimation(horizontal);
        Jump(verticalInput);
        Crouch();
    }
    void MoveCharecter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * playerSpeed * Time.deltaTime;
        transform.position = position;
    }

    private void MovementAnimation(float horizontal)
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        //Jump(verticalInput);
        Crouch();

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
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", true);

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", false);
        }
    }
    void Jump(float verticalInput)
    {
        if (verticalInput > 0)
        {
         animator.SetTrigger("jump");
        }
    }
}
