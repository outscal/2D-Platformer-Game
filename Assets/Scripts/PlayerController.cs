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


    void Awake()
    {
        BoxcolliderInitialSize = boxCollider.size;
        BoxcolliderInitialOffSet = boxCollider.offset;
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
        if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            if (!animator.GetBool("Crouch"))
            {
                animator.SetBool("Crouch", true);
                boxCollider.size = BoxColliderReducedSize;
                boxCollider.offset = BoxColliderReducedOffSet;
            }
            else
            {
                animator.SetBool("Crouch", false);
                boxCollider.size = BoxcolliderInitialSize;
                boxCollider.offset = BoxcolliderInitialOffSet;
            }
        }
    }

    private void Run()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void Jump()
    {
        if (!animator.GetBool("Jump"))
        {
            float speed = Input.GetAxisRaw("Vertical");
            if (speed > 0)
            {
                animator.SetBool("Jump", true);
                //animator.SetBool("Jump", false);
            }
        }
    }
    
}
