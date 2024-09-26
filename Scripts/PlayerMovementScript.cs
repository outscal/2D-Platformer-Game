using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public float speed, HorizontalValue;
    public Animator animator;

    Vector2 originalColliderSize,originalOffset;

    Rigidbody2D rgbd;
    BoxCollider2D PlayerCollider;


        private void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<BoxCollider2D>();
        originalColliderSize = PlayerCollider.size;
        originalOffset = PlayerCollider.offset;
    }
   

    // Update is called once per frame
    void Update()
    {
        HorizontalInput();
        SetAnimatorSpeedValue();
    }

    private void HorizontalInput() {

      HorizontalValue = Input.GetAxisRaw("Horizontal"); 
    }

        private void SetAnimatorSpeedValue()
    {
        CheckFlipped();
        animator.SetFloat("Speed", Mathf.Abs(HorizontalValue));
    }

    private void CheckFlipped()
    {
        Vector3 scale = transform.localScale;
        if (HorizontalValue < 0)
        {
            scale.x = -1 *Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void InputForCrouch()
    {
        if(Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isCrouch", true);
            PlayerCollider.size = new Vector2(PlayerCollider.size.x, 1.2f);
            PlayerCollider.offset = new Vector2(PlayerCollider.offset.x, .6f);
            speed = 6; // moves slow when crouching
        }
        else
        {
            animator.SetBool("isCrouch", false);
            PlayerCollider.size = originalColliderSize;
            PlayerCollider.offset = originalOffset;
            speed = 8;
        }
    }
}
