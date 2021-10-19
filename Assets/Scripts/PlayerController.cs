using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed = 2f;
    private Rigidbody2D rB2d;
    public float jumpForce;
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

        if (Input.GetButton("Fire1")){
            animator.SetBool("Crowch", true);
        }
        else{
            animator.SetBool("Crowch", false);
        }
    
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
        
        if (verticle > 0)
        {
            animator.SetBool("Jump", true);
        }
        else{
            animator.SetBool("Jump", false);
        }
    }
    private void MoveCharector(float horizontal, float verticle){
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if (verticle > 0){
        rB2d.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Force);
        }
    }
}
