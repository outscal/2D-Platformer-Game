using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;
    private void Awake()
    {
        Debug.Log("Player Controller Awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    private void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Jump");
        PlayerMovementAnimation(Horizontal,Vertical);
        MoveCharacter(Horizontal,Vertical);
    }
    private void PlayerMovementAnimation(float Horizontal,float Vertical)
    {
        animator.SetFloat("AnimSpeed", Mathf.Abs(Horizontal));

        //Horizontal Animator Panel
        Vector3 scale = transform.localScale;
        if (Horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(Horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Vertical Animator Panel
        if (Vertical > 0)
        {
            animator.SetBool("AnimJump", true);
        }
        /*else if(Vertical < 0)
        {
            animator.SetBool("Crouch", true);
        }*/
        else
        {
            animator.SetBool("AnimJump", false);
            //animator.SetBool("AnimCrouch", false);
        }
    }
    private void MoveCharacter(float Horizontal,float Vertical)
    {
        //move character horizontally
        Vector3 position = transform.position;
        position.x += Horizontal*speed*Time.deltaTime;
        transform.position = position;

        //move character vertically
        if(Vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f,jump), ForceMode2D.Force);
        }
    }
    
}
