using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    float horizontal,vertical;
    private Animator Animator;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Animator   = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0)
        {                      
            Vector3 Scale = transform.localScale;
            Scale.x = Mathf.Abs(Scale.x);
            transform.localScale = Scale;
            Animator.SetBool("IsMoving", true);
            PlayerMovement(horizontal);            
        }
        else if(horizontal < 0)
        {            
            Vector3 Scale = transform.localScale;
            Scale.x = -1f * Mathf.Abs(Scale.x);
            transform.localScale = Scale;
            Animator.SetBool("IsMoving", true);
            PlayerMovement(horizontal);
        }
        else if(Input.GetAxisRaw("Vertical")>0)
        {
            Animator.SetBool("IsJumping", true);
        }
        else if(Input.GetKey(KeyCode.C))
        {            
            Animator.SetBool("IsCrounched",true);
        }
        else
        {
            Animator.SetBool("IsMoving",false);
            Animator.SetBool("IsCrounched", false);
            Animator.SetBool("IsJumping", false);
        }
    }

    void PlayerMovement(float horizontal)
    {
        Vector3 Position = transform.position;
        Position.x = Position.x + horizontal * speed * Time.deltaTime;
        transform.position = Position;
    }
}
