using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    private Vector3 scale, position;
    private bool isRunning;
    [SerializeField] private float speed;


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
        horizontalAxisValue = Input.GetAxisRaw("Horizontal");
        verticalAxisValue = Input.GetAxisRaw("Vertical");

        MoveCharacter(horizontalAxisValue);
        PlayerMovementAnimation(horizontalAxisValue, verticalAxisValue);
        Crouch();
    }


    private void MoveCharacter(float horizontal)
    {
        position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }


    private void Crouch()
    {
        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (!isRunning)
            {
                animator.SetBool("Crouch", true);
                boxCollider.size = BoxColliderReducedSize;
                boxCollider.offset = BoxColliderReducedOffSet;              
            }
        }
        else
        {
            animator.SetBool("Crouch", false);
            boxCollider.size = BoxcolliderInitialSize;
            boxCollider.offset = BoxcolliderInitialOffSet;
        }
    }


    private void PlayerMovementAnimation(float horizontalValue, float verticalValue)
    {
        //run
        animator.SetFloat("Speed", Mathf.Abs(horizontalValue));

        scale = transform.localScale;
        if (horizontalValue < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            isRunning = true;
        }
        else if (horizontalValue > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        transform.localScale = scale;

        //jump
        if (verticalValue > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
