using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Vector2 newCrouchColliderOffset;
    [SerializeField] protected Vector2 newCrouchColliderSize;

    private enum PlayerState
    {
        idle, 
        walking,
        running,
        crouching,
        jumping
    };

    private Vector2 originalColliderOffset;
    private Vector2 originalColliderSize;
    private PlayerState state;
    private BoxCollider2D collider;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0f;
        state = PlayerState.idle;
        collider = GetComponent<BoxCollider2D>();
        originalColliderOffset = collider.offset;
        originalColliderSize = collider.size;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        CheckDirection();
    }

    void GetPlayerInput()
    {
        speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        if (Input.GetKey(KeyCode.LeftControl))
        {
            state = PlayerState.crouching;
            ResizeCollider();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            state = PlayerState.idle;
            RestoreColliderSize();
        }

        if (Input.GetAxisRaw("Vertical") > 0f)
            animator.SetTrigger("PlayerJumped");

        animator.SetInteger("PlayerState", (int)state);
    }

    void RestoreColliderSize()
    {
        collider.offset = originalColliderOffset;
        collider.size = originalColliderSize;
    }

    void ResizeCollider()
    {
        collider.offset = newCrouchColliderOffset;
        collider.size = newCrouchColliderSize;
    }

    void CheckDirection()
    {
        if (speed < 0f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            state = PlayerState.walking;
        }
        else if (speed > 0.1f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            state = PlayerState.walking;
        }
    }
}
