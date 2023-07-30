using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private BoxCollider2D playerCollider;
    private Rigidbody2D playerBody;

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
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        ctrlPressed = (Input.GetKey(KeyCode.LeftControl)) || (Input.GetKey(KeyCode.RightControl)) ;
        animator.SetBool("IsCrouching", ctrlPressed);

        float verticalInput = Input.GetAxis("Vertical");
        animator.SetFloat("Vertical", Mathf.Abs(verticalInput));
        //Flipping the player 
        Vector3 scale = transform.localScale;
        if(speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        } else if(speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

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

}
