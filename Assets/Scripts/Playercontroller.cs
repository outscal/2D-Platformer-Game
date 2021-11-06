using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jump;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();    
    }
        // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        Debug.Log(vertical);
        // playerInput();
        movePlayer(horizontal,vertical);
        playerMovementAnimation(horizontal, vertical);
    }
    private void playerMovementAnimation(float horizontal,float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        flipPlayer(horizontal);
        jumpPlayer(vertical);
    }
    private void jumpPlayer(float vertical)
    {
        if (vertical > 0)
        {
             animator.SetBool("jump", true);
           
        }
            
        else 
            animator.SetBool("jump", false);
    }
    private void movePlayer(float horizontal,float vertical)
    {
        Vector3 temp = transform.position;
        temp.x = temp.x + horizontal * speed * Time.deltaTime;
        transform.position = temp;
        if (vertical > 0)
        {
            
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }

       

    }
    void playerInput()
    {
        
        float speedJump = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(speed));
              
    }
    void flipPlayer(float speed)
    {
        Vector2 scale = transform.localScale;
        if (speed < 0)scale.x = -1.0f * Mathf.Abs(scale.x);
        else if (speed > 0) scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}
