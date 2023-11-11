using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpSpeed;

    private Animator playerAnim;
    private Rigidbody2D playerRb;
    private float horizontalSpeed;
    private float verticalSpeed;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalSpeed = Input.GetAxisRaw("Horizontal");
        verticalSpeed = Input.GetAxisRaw("Jump");

        PlayerAnimation();
        PlayerMovement();
    }

    void PlayerAnimation()
    {
        playerAnim.SetFloat("Speed", horizontalSpeed);
        Vector2 scale = transform.localScale;
        if (horizontalSpeed < 0)
        {
            playerAnim.SetFloat("Speed", Mathf.Abs(horizontalSpeed));
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerAnim.SetBool("canCrouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerAnim.SetBool("canCrouch", false);
        }


        if (verticalSpeed > 0)
        {
            playerAnim.SetBool("canJump", true);
        }
        else
        {
            playerAnim.SetBool("canJump", false);
        }
    }

    void PlayerMovement()
    {
        Vector2 playerPosition = transform.position;
        if(Mathf.Abs(horizontalSpeed) > 0)
        {
            playerPosition.x += horizontalSpeed * playerSpeed * Time.deltaTime;
            transform.position = playerPosition;
        }

        if(verticalSpeed > 0)
        {
            playerRb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Force);
        }
    }
}
