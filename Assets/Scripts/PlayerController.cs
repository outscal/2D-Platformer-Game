using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxcollider;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;
    private float size = 1.22f;
    private float offset = 0.59f;
    private float size1 = 0.98f;
    private float offset1 = 2.011f;

    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("Player controller awake");
        rb2d=gameObject.GetComponent<Rigidbody2D>();
        boxcollider=gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame   
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal,vertical);
        PlayMovementAnimation(horizontal, vertical);

    }

    

    private void MoveCharacter(float horizontal,float vertical)
    {
        speed = 4;
        //Move Character Horizontally
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //Move Character Vertically
        if(vertical > 0)
        {
            jump = 30;
            rb2d.AddForce( new Vector2(0f,jump), ForceMode2D.Force);
        }
    }

    private void PlayMovementAnimation(float horizontal,float vertical)
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

        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        if (Input.GetKey(KeyCode.LeftControl) == true)
        {
            animator.SetBool("isSit", true);
            boxcollider.size = new Vector2(boxcollider.size.x, size);
            boxcollider.offset = new Vector2(boxcollider.offset.x, offset);

        }
        else
        {
            animator.SetBool("isSit", false);
            boxcollider.offset = new Vector2(boxcollider.offset.x, size1);
            boxcollider.size = new Vector2(boxcollider.size.x, offset1);
        }
    }
}
