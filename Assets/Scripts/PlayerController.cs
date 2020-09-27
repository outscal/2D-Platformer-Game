using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    BoxCollider2D Collider;

    public float speed;
    public float Jump;
    private Rigidbody2D rb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision " + collision.gameObject.name);
    }
    void Awake()
    {
        Collider = GetComponent<BoxCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayerMovementHorizontal(horizontal,vertical);
        MoveCharacter(horizontal,vertical);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", true);
            Collider.offset = new Vector2(-0.013f, 0.64f);
            Collider.size = new Vector2(0.95f, 1.33f);
            
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", false);
            Collider.offset = new Vector2(0.013f, 0.983f);
            Collider.size = new Vector3(1.6f, 2.1f);
        }

       
        
        
    }

    private void MoveCharacter(float horizontal,float vertical)
    {
        Vector2 pos = transform.position;
        pos.x +=  horizontal * speed * Time.deltaTime;
        
        transform.position = pos;

        if (vertical > 0)
        {
            rb.AddForce(new Vector2(0f, Jump), ForceMode2D.Force);
        }
    }

    private void PlayerMovementHorizontal(float horizontal,float vertical)
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
            animator.SetBool("IsJump", true);
        }
        else
        {
            animator.SetBool("IsJump", false);
        }
    }
}


