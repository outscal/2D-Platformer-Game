using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;

    private Rigidbody2D rigid;

    public void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Jump"); 

        MoveCharacter(horizontal,vertical);
        PlayMovementAnimation(horizontal,vertical);

    }

    private void MoveCharacter(float horizontal,float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if(vertical > 0)
        {
            rigid.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void PlayMovementAnimation(float horizontal,float vertical)
    {
        // Run Animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        
        //Jump Animation 

        if (vertical > 0 )
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
          
        //Fliping Character
        Vector3 scale = transform.localScale;

        if(horizontal < 0f)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(horizontal > 0f)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
}
