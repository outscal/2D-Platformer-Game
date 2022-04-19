using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    private Rigidbody2D rb2d;
    public float speed;
    public float jump;


    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal, vertical);
        PlayerAnimationMovement(horizontal, vertical);

       

    }

    //Character Movement
    private void MoveCharacter(float horizontal, float vertical)
    {
        //horizontal
        Vector3 position = transform.position;
        position.x += horizontal *speed * Time.deltaTime;
        transform.position = position;

        //vertical
       if(vertical > 0)
       {
           rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
       }
    }
    //Player Movement Animation 
    private void PlayerAnimationMovement(float horizontal, float vertical)
    {
        //Animation : actual player movement along x axis
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

         //Jump animation along y axis
        if(vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
