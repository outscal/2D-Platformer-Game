using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private BoxCollider2D playerCollider;
    public float initialYoffset, initialYsize, crouchYoffset = 0.07785285f, crouchYsize= 1.278029f;
    public float speed;
    private Rigidbody2D rigbod2d;
    public float jump;
    // Start is called before the first frame update
    void Start()
    {
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        initialYoffset=playerCollider.offset.y; 
        initialYsize = playerCollider.size.y;
        rigbod2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        //Debug.Log("Player Speed is:"+horizontal);
        float vertical = Input.GetAxisRaw("Vertical");
        //Debug.Log("Player can jump : "+vertical);
        PlayerMovementAnimation(horizontal,vertical);
        MovePlayer(horizontal,vertical);
    }

    private void MovePlayer(float horizontal,float vertical)
    {
        //Move player horizontally
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //Move player vertically
        if(vertical>0)
        {
            rigbod2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void PlayerMovementAnimation(float horizontal,float vetical)
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

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", true);
            playerCollider.offset = new Vector2(playerCollider.offset.x, crouchYoffset);
            playerCollider.size = new Vector2(playerCollider.size.x, crouchYsize);
        }
        else
        {
            animator.SetBool("isCrouch", false);
            playerCollider.offset = new Vector2(playerCollider.offset.x, initialYoffset);
            playerCollider.size = new Vector2(playerCollider.size.x, initialYsize);
        }
        
        if (vetical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
