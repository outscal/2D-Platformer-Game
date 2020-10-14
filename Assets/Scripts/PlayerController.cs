using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;




public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private Rigidbody2D rb2d;
    public float jump;


    private void Awake()
    {
        Debug.Log("Player Controllor Awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collison : " + collision.gameObject.name);
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        playerMoveAnime(horizontal ,vertical);
        movePlayerHorizontal(horizontal,vertical);

    }

    private void movePlayerHorizontal(float horizontal,float vertical)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
        if(vertical > 0 )
        {
            rb2d.AddForce(new Vector2(0f,jump), ForceMode2D.Force);
        }
    }
    private void playerMoveAnime(float horizontal, float vertical)
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
        if (vertical > 0)
        {
            animator.SetBool("Jump",true);
        }
        else
        {
            animator.SetBool("Jump",false);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1f, 1.883191f);
            animator.SetBool("crouch", true);

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1f, 1.983191f);
            animator.SetBool("crouch", false);
        }

        
    }
}