using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb2d;


    public float speed;
    public float jump;
    public bool isCrouching = false;

    private void Start()    
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame//
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float verticle = Input.GetAxisRaw("Jump");
        PlayMovementAnimation(horizontal,verticle);
        MoveCharacter(horizontal,verticle);

    }
    private void MoveCharacter(float horizontal,float verticle )
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;


        if (verticle > 0)
            {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
            }
        if(isCrouching )
    }
   

    private void PlayMovementAnimation(float horizontal,float verticle)
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
       
        if (verticle > 0)
            animator.SetBool("Jump", true);
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
