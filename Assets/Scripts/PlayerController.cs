using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;




public class PlayerController : MonoBehaviour
{
    public Animator animator;
<<<<<<< HEAD
    public float speed;
    private Rigidbody2D rb2d;
    public float jump;


=======
    public bool crouch = false;
>>>>>>> parent of 19ad41b... Move animation horizontal
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
<<<<<<< HEAD
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
=======
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(speed));
>>>>>>> parent of 19ad41b... Move animation horizontal
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0 )
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
<<<<<<< HEAD
        if (vertical > 0)
        {
            animator.SetBool("Jump",true);
        }
        else
        {
            animator.SetBool("Jump",false);
        }
=======

        
            
        

>>>>>>> parent of 19ad41b... Move animation horizontal
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