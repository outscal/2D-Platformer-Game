using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public Animator animator;

    public float  speed;
    public float jump;
    private Rigidbody2D rgbd2;
    

     private void Awake()
     {
         Debug.Log("PlayerController Awake");
        rgbd2 = gameObject.GetComponent<Rigidbody2D>();
        SpriteRenderer sprite=gameObject.GetComponent <SpriteRenderer>();
     }
     private void OnCollisionEnter2D(Collision2D collision)
     {
         Debug.Log("Collision :" + collision.gameObject.name);
     }
     private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayerMovementAnimation(horizontal,vertical);
        MoveCharacter(horizontal,vertical);

       
    }
      private void MoveCharacter(float horizontal,float vertical)
    {
        //move character horizontally
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        //move character vertically
        if (vertical > 0) {
            rgbd2.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }  

     private void PlayerMovementAnimation(float horizontal,float vertical)
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));

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
        //Jump
        
        if (vertical>0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}