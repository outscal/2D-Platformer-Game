using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    public float speed;
    public float jump;

    private Rigidbody2D rb2d;

    public ScoreController scoreController;

    //Take a reference from inspector.

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }


    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal , vertical);
        PlayMovementAnimation(horizontal , vertical);

       


    }

    private void MoveCharacter(float horizontal , float vertical)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        if (vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }

    }

    private void PlayMovementAnimation(float horizontal , float vertical)
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal));


        //Flipping the player

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

        

        if (vertical >0 )
        {
            playerAnimator.SetBool("Jump", true);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
        }
    }

    public void pickUpKey()
    {
        Debug.Log("Key is pickedup");
        scoreController.IncreaseScore(10);
    }
}
