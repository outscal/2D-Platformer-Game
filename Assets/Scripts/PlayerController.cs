using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    
    [SerializeField]  private float _speed =5.0f;
    [SerializeField] private float _jump = 15.0f;  // jump force added
    private Rigidbody2D rb2D;
    public bool isJumping;
    public bool isCrouch; 
    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
        isCrouch = false;
        rb2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()    {


        float _speedInput = Input.GetAxisRaw("Horizontal");
        float _verticalMovement = Input.GetAxisRaw("Jump");  // configured to space key

        isCrouch = Input.GetButtonDown("Crouch");  // 
        
            PlayerAnimationMovement(_speedInput, _verticalMovement);
            PlayerTransformMoves(_speedInput, _verticalMovement);

        
     

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            Debug.Log("isJumping is false");
            isJumping = false; 
        }
    }

   
    void PlayerTransformMoves(float _speedInput, float _verticalMovement)
    {
        Vector3 position = transform.position;

        position.x += _speedInput * _speed * Time.deltaTime;

        transform.position = position; 

        // JUMP 

        if(_verticalMovement > 0 && !isJumping)  // vertical input with space key
        {
            Debug.Log("Player jumping" +isJumping); 
            isJumping = true; 
            rb2D.AddForce(new Vector2(0,_jump), ForceMode2D.Impulse); 
        } 
    }

  
   

    void PlayerAnimationMovement(float _speedInput , float _verticalMovement )
    {
        //MOVE
        animator.SetFloat("speed", Mathf.Abs(_speedInput));
        Vector3 scale = transform.localScale;
        if (_speedInput < 0)
        {

            scale.x = -1f * Mathf.Abs(scale.x);           

        }
        else if (_speedInput > 0)
        {

            scale.x = Mathf.Abs(scale.x);

        }
        transform.localScale = scale;


        // JUMP 

        if (_verticalMovement > 0 )
        {
            animator.SetBool("isJumping", true);

        }
        else
        {
            animator.SetBool("isJumping", false);

        }

        // CROUCH

        if (isCrouch)
        {
            animator.SetBool("isCrouch", true);
            isCrouch = false; 
        }
        else 
        {
            animator.SetBool("isCrouch", false);
            Debug.Log("IS crouch is false"); 
        }
    }
}
