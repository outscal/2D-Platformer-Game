using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public float movementSpeed;
    public float jump;
    private Rigidbody2D rb2d;

   public void PickUpKey()
    { 
        scoreController.IncreaseScore(10);
    }

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        PlayerMovement(horizontal, vertical);
        PlayCrouchAnimation();
        PlayJumpAnimation(vertical);
        PlayHorizontalAnimation(horizontal);
        
    }
    private void PlayerMovement(float horizontal, float vertical)
    {
        //for horizontal
        Vector3 position = transform.position;
        position.x += horizontal * movementSpeed * Time.deltaTime;
        transform.position = position;

        if (vertical > 0)
        {
          rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }
    private void PlayCrouchAnimation()
    {
        animator.SetBool("Crouch", Input.GetKey(KeyCode.LeftControl));
    }
    private void PlayJumpAnimation(float vertical)
    {
        animator.SetBool("Jump", vertical > 0);
    }
    private void PlayHorizontalAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        scale.x = (horizontal < 0 ? -1 : (horizontal > 0 ? 1 : scale.x)) * Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
        
       

    
}
