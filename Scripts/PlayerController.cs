using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float Speed;
    public float jump;

    private Rigidbody2D rb2d;
    private BoxCollider2D boxCollider;

    [SerializeField] private LayerMask platformLayerMask;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
       
        PlayerMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);

        // play crouch animation
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            if(animator != null)
            {
                animator.SetBool("Crouch", true);
            }
        }
        else
        {
            if(animator != null)
            {
                animator.SetBool("Crouch", false);
            }
        }
        
    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
        if(animator != null)
        {
            // Setting float value of speed inside animator
            animator.SetFloat("Speed", Mathf.Abs(horizontal));

            // Setting value of 'jump' boolean
            if (vertical > 0 && IsGrounded())
            {
                animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("Jump", false);
            }
        }

        // Change the direction of player
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
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        // Horizontal character movement
        Vector3 position = transform.position;
        position.x += horizontal * Speed * Time.deltaTime;
        transform.position = position;

        // Vertical Character movement
        if(vertical > 0 && IsGrounded())
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit ;
        float extraHeight = 0.3f;

        raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);            
        return raycastHit.collider != null;
    }

}
