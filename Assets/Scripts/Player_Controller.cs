using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    float horizontal,vertical;
    private Animator Animator;
    public float speed;
    public GameObject UI_object;
    public float jumpForce;

    private Rigidbody2D rgbody;
    // Start is called before the first frame update
    void Start()
    {
        Animator   = GetComponent<Animator>();
        rgbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal > 0)
        {
            Animator.SetBool("IsMoving", true);
            Vector3 Scale = transform.localScale;
            Scale.x = Mathf.Abs(Scale.x);
            transform.localScale = Scale;           
            PlayerMovement(horizontal);            
        }
        else if(horizontal < 0)
        {
            Animator.SetBool("IsMoving", true);
            Vector3 Scale = transform.localScale;
            Scale.x = -1f * Mathf.Abs(Scale.x);
            transform.localScale = Scale;            
            PlayerMovement(horizontal);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            Animator.SetBool("IsJumping", true);
            rgbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);

        }
        else if(Input.GetKey(KeyCode.C))
        {            
            Animator.SetBool("IsCrounched",true);
        }
        else
        {
            Animator.SetBool("IsMoving",false);
            Animator.SetBool("IsCrounched", false);
            Animator.SetBool("IsJumping", false);
        }
    }

    void PlayerMovement(float horizontal)
    {
        Vector3 Position = transform.position;
        Position.x = Position.x + horizontal * speed * Time.deltaTime;
        transform.position = Position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Finish")
        {
            UI_object.SetActive(true);
        }
    }
}
