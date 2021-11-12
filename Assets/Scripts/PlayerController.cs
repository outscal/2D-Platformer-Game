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
        Debug.Log("Player Controller Awake!!!");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision:" + collision.gameObject.name);
    }*/

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        

        MoveCharecter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);
    }

    private void MoveCharecter(float horizontal, float vertical)
    {
        // Move charecter horizontally
        Vector3 position = transform.position;
        // (Distance / Time-Sec) * (1 / 30 Frames per Sec - FPS)
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        // Move charecter vertically
        if(vertical > 0)
        {
           rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
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

        //Jump

        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        //Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }

    }
}
