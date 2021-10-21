using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed = 2f;
    private Rigidbody2D rB2d;
    public float jumpForce;
    private bool isGrounded = true;
    // Start is called before the first frame update
    private void Awake(){
        rB2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float verticle = Input.GetAxisRaw("Jump");
        

        MoveCharector(horizontal, verticle);
        methodAnimationRun(horizontal, verticle);

        animator.SetBool("Crowch", Input.GetButton("Fire1"));

    
    }

    private void methodAnimationRun(float horizontal, float verticle){
        
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0 && scale.x > 0)
        {
            scale.x = -1f* scale.x;
        }
        else if(horizontal > 0){
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        

        animator.SetBool("Jump", verticle > 0);

    }
    private void MoveCharector(float horizontal, float verticle){
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if (verticle > 0 && isGrounded){
        isGrounded = false;
        rB2d.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

}
