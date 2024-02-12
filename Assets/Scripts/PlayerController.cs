using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider;
    private Vector2 BoxcolliderInitialSize;
    private Vector2 BoxcolliderInitialOffSet;
    [SerializeField] private Vector2 BoxColliderReducedSize;
    [SerializeField] private Vector2 BoxColliderReducedOffSet;
    private float horizontalAxisValue, verticalAxisValue;
    private Vector3 scale;
    private bool isRunning;


    void Awake()
    {
        BoxcolliderInitialSize = boxCollider.size;
        BoxcolliderInitialOffSet = boxCollider.offset;
        isRunning = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Crouch();
        Run();
        Jump();
    }

    private void Crouch()
    {
        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (!isRunning)
            {
                if (!animator.GetBool("Crouch"))
                {
                    animator.SetBool("Crouch", true);
                    boxCollider.size = BoxColliderReducedSize;
                    boxCollider.offset = BoxColliderReducedOffSet;
                }              
            }
        }
        else
        {
            animator.SetBool("Crouch", false);
            boxCollider.size = BoxcolliderInitialSize;
            boxCollider.offset = BoxcolliderInitialOffSet;
        }
    }

    private void Run()
    {
        
        horizontalAxisValue = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalAxisValue));

        scale = transform.localScale;
        if (horizontalAxisValue < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            isRunning = true;
        }
        else if (horizontalAxisValue > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        transform.localScale = scale;
    }

    private void Jump()
    {
        verticalAxisValue = Input.GetAxisRaw("Vertical");

        if (verticalAxisValue > 0)
        {
           animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
