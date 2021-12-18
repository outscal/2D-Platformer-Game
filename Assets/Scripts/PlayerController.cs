using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public ScoreController scoreController;

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

    public void PickUpKey()
    {
        Debug.Log("Key");
        scoreController.IncreaseScore(10);
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayerMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);
        Crouch();
    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        animator.SetBool("Jump", (vertical > 0 && IsGrounded()));

        Vector3 scale = transform.localScale;
        scale.x = horizontal < 0 ? -1f * Mathf.Abs(scale.x) : horizontal > 0 ? Mathf.Abs(scale.x) : scale.x ;
        transform.localScale = scale;
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * Speed * Time.deltaTime;
        transform.position = position;

        rb2d.AddForce(new Vector2(0f, ((vertical > 0 && IsGrounded()) ? jump : 0f)), ForceMode2D.Force);
    }

    private void Crouch()
    {
        animator.SetBool("Crouch", (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)));
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.3f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
        return raycastHit.collider != null;
    }

}
