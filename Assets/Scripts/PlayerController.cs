using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public float Speed;
    public float jump;
    private Rigidbody2D rb2d;
    private void Awake()
    {
        Debug.Log("Player Awake");
       rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        PlayerMoveAnimation(horizontal,vertical);
        MoveCharacter(horizontal,vertical);
        CrouchAnimation();

    }
    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * Speed * Time.deltaTime;
        transform.position = position;

        if(vertical>0)
        {
            rb2d.AddForce(new Vector2(0f, jump),ForceMode2D.Force);

        }
    }
    private void CrouchAnimation()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }
    }

    private void PlayerMoveAnimation(float horizontal, float vertical)
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
        //JUMP

        //float vertical = Input.GetAxisRaw("Jump");
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);

        }
        else
        {
            animator.SetBool("Jump", false);
        }

    }
    
}
