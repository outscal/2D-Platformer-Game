using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCol;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private GameOverController gameOverController;
    [SerializeField] private bool isCrouch;

    internal void KillPlayer()
    {
        scoreController.DecreaseHeart();

        if (scoreController.HeartOver())
        {
            this.enabled = false;
            playerAnimator.SetTrigger("Died");
            gameOverController.PlayerDied();
        }
    }


    //Collider Variables
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;

    public float speed;

    public void PickUpKey()
    {
        scoreController.IncreaseScore(1);
    }

    public float jumpForce;
    public bool isGrounded = false;
    public Rigidbody2D rigidbody2D;

    private void Start()
    {
        //Fetching initial collider properties
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;

        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxisRaw("Jump");
        bool jump = Input.GetKeyDown(KeyCode.Space);
        PlayerMovementAnimation(horizontal, jump);
        PlayerMovement(horizontal, jump);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("isCrouch - " + isCrouch);

            isCrouch = !isCrouch;

            Crouch(isCrouch);
        }
    }

    private void PlayerMovement(float horizontal, bool jump)
    {
        if (isCrouch) return;

        if (horizontal != 0)
        {
            Vector2 pos = transform.position;
            pos.x += speed * horizontal * Time.deltaTime;

            transform.position = pos;
        }

        if (jump && isGrounded)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce * 1000), ForceMode2D.Force);
        }

    }

    private void PlayerMovementAnimation(float horizontal, bool jump)
    {
        if (isCrouch) return;

        if (horizontal != 0 && isGrounded)
        {
            playerAnimator.SetBool("Speed", true);
        }
        else
        {
            playerAnimator.SetBool("Speed", false);
        }

        Vector2 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }

        if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (jump && isGrounded)
        {
            playerAnimator.SetBool("Jump", true);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
        }
    }

    public void Crouch(bool crouch)
    {
        if (crouch == true)
        {
            float offX = -0.12494f;
            float offY = 0.61027f;

            float sizeX = 0.8923f;
            float sizeY = 1.3452f;

            boxCol.size = new Vector2(sizeX, sizeY);
            boxCol.offset = new Vector2(offX, offY);
        }

        else
        {
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }

        playerAnimator.SetBool("Crouch", crouch);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "platform")
        {
            isGrounded = false;
        }
    }
}
