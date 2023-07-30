using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private BoxCollider2D playerCollider;
    private Rigidbody2D playerBody;

    public float speed;
    private bool ctrlPressed = false;
   
    private void Awake()
    {
        Debug.Log("Player controller awake");
    }

    private void Start()
    {
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
        playerBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        MoveCharacter(horizontal);
        PlayMovementAnimation(horizontal);

        ctrlPressed = (Input.GetKey(KeyCode.LeftControl)) || (Input.GetKey(KeyCode.RightControl)) ;
        animator.SetBool("IsCrouching", ctrlPressed);

        float verticalInput = Input.GetAxis("Vertical");
        animator.SetFloat("Vertical", Mathf.Abs(verticalInput));

        //Crouch Animation
        if (ctrlPressed)
        {
            playerCollider.offset = new Vector2(-0.12f, 0.6f);
            playerCollider.size = new Vector2(0.9f, 1.3f);
        }
        else
        {
            playerCollider.offset = new Vector2(0f, 0.95f);
            playerCollider.size = new Vector2(0.6f, 2f);
        }

        //Jump Animation
        if( verticalInput > 0 )
        {
           animator.SetBool("IsJumping", true);

        } else if(verticalInput<=0)
        {
            animator.SetBool("IsJumping", false);
        }
        
    }

    private void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position; 
    }

    private void PlayMovementAnimation(float horizontal)
    {
         animator.SetFloat("Speed", Mathf.Abs(horizontal));
        //Flipping the player 
        Vector3 scale = transform.localScale;
        if(horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        } else if(horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

}
