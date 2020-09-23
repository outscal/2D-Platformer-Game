using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    [SerializeField]  private float _speed =5.0f;
    [SerializeField] private float _jump = 25.0f;  // jump force 
    private Rigidbody2D rb2D; 
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()    {


        float _speedInput = Input.GetAxisRaw("Horizontal");
        float _verticalMovement = Input.GetAxisRaw("Jump");
        bool _isCrouch = false;
        _isCrouch = Input.GetButtonDown("Crouch"); 

        PlayerAnimationMovement(_speedInput, _verticalMovement,_isCrouch);
        PlayerTransformMoves(_speedInput, _verticalMovement);

    }


    void PlayerTransformMoves(float _speedInput, float _verticalMovement)
    {
        Vector3 position = transform.position;

        position.x += _speedInput * _speed * Time.deltaTime;

        transform.position = position; 

        // JUMP 

        if(_verticalMovement > 0)
        {
            rb2D.AddForce(new Vector2(0,_jump), ForceMode2D.Force); 
        } 
    }

    void PlayerAnimationMovement(float _speedInput, float _verticalMovement, bool _isCrouch)
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

        if (_verticalMovement > 0)
        {
            animator.SetBool("isJumping", true);

        }
        else
        {
            animator.SetBool("isJumping", false);

        }

        // CROUCH

        if (_isCrouch)
        {
            animator.SetBool("isCrouch", true);

        }
        else
        {
            animator.SetBool("isCrouch", false);

        }
    }
}
