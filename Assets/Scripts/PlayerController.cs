using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Update is called once per frame

    //this enables us to add GameObject/Prefab to the Script
    public Animator animator;
    public float acceleration;
    public float jump;
    

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log("Game has started");
    }
    private void Update()
    {

        float speed = Input.GetAxisRaw("Horizontal");
        float leap = Input.GetAxisRaw("Jump");
        PlayCrouchAnimation();
        PlayJumpAnimation();
        PlayHorizontalAnimation(speed);
        PlayerMovement(speed, leap);

        
    }

    private void PlayerMovement(float speed, float leap)
    {
        //for horizontal
        Vector3 position = transform.position;
        position.x += speed * acceleration * Time.deltaTime;
        transform.position = position;

        
        //if (leap > 0)
        //{
        //    rb2d.AddForce(new Vector2(0f, leap), ForceMode2D.Force);
        //}
    }
    private void PlayCrouchAnimation()
    {
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        if (crouch == true)
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }
    }

    private void PlayJumpAnimation()
    {
        bool jump = Input.GetKey(KeyCode.Space);
        if (jump == true)
        {
            animator.SetBool("Jump", true);
            transform.Translate(Vector3.up * 10 * Time.deltaTime, Space.World);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void PlayHorizontalAnimation(float speed)
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            //transform.Translate(Vector3.left * 3 * Time.deltaTime, Space.World);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            //transform.Translate(Vector3.right * 3 * Time.deltaTime, Space.World);
        }
        transform.localScale = scale;
    }
        
       

    
}
