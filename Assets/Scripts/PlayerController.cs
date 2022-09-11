using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField]private BoxCollider2D boxCollider;

    public Vector2 standingColliderOffset;
    public Vector2 standingColliderSize;
    public Vector2 crouchColliderOffset;
    public Vector2 crouchColliderSize;

    private void Start()
    {
        CrouchHitBox(false);
    }

    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        PlayRunAnimation(xAxis);

        if(Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch",true);
            CrouchHitBox(true);
        }
        else
        {
            animator.SetBool("Crouch", false);
            CrouchHitBox(false);
        }

        float yAxis = Input.GetAxisRaw("Vertical");
        if(yAxis >0)
        {
           animator.SetTrigger("Jump"); 
        }
        else
        {
            animator.ResetTrigger("Jump");
        }
    }

    private void PlayRunAnimation(float xAxis)
    {
        animator.SetFloat("Speed", Mathf.Abs(xAxis));

        Vector3 scale = transform.localScale;

        if (xAxis < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (xAxis > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    private void CrouchHitBox(bool crouch)
    {
        if(crouch)
        {
            boxCollider.offset = crouchColliderOffset;
            boxCollider.size = crouchColliderSize;
        }
        else
        {
            boxCollider.offset = standingColliderOffset;
            boxCollider.size = standingColliderSize;
        }
    }
}
