using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public ScoreController scoreController;
    public GameObject gameOver;

    public float Speed;
    public float jump;

    private bool isCrouch = false;
    public bool isDead = false;

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
        SoundManager.Instance.Play(SoundManager.Sounds.Pickup);
        scoreController.IncreaseScore(10);
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        if (!isDead)
        {
            PlayerMovement(horizontal, vertical);
            Jump(horizontal, vertical);
            Crouch();
        }
    }

    private void PlayerMovement(float horizontal, float vertical)
    {
        if (!isCrouch)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));

            Vector3 scale = transform.localScale;
            scale.x = horizontal < 0 ? -1f * Mathf.Abs(scale.x) : horizontal > 0 ? Mathf.Abs(scale.x) : scale.x;
            transform.localScale = scale;

            Vector3 position = transform.position;
            position.x += horizontal * Speed * Time.deltaTime;
            transform.position = position;
        }
    }

    private void Jump(float horizontal, float vertical)
    {
        animator.SetBool("Jump", (vertical > 0 && IsGrounded() && !isCrouch));

        if (vertical > 0 && IsGrounded() && !isCrouch)
        {
            rb2d.velocity = Vector2.up * jump;
        }
    }

    private void Crouch()
    {
        animator.SetBool("Crouch", (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)));
        isCrouch = (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl));
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.3f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
        return raycastHit.collider != null;
    }

    public void KillPlayer()
    {
        isDead = true;
        animator.SetTrigger("Death");
        SoundManager.Instance.Play(SoundManager.Sounds.PlayerDeath);
        Invoke("ReloadLevel", 2f);
    }

    public void ReloadLevel()
    {
        gameOver.SetActive(true);
    }

    public void MovementSound()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.PlayerMove);
    }

    public void JumpSound()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.Jump);
    }

}
