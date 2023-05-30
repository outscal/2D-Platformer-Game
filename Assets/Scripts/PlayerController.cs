using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2D;

    //Crouch related
    public BoxCollider2D playerCollider;
    bool isCrouching = false;
    Vector2 originalSize;
    Vector2 crouchSize = new Vector2((float)0.5, 1);


    private void Awake()
    {
        Debug.Log("Player Controller Awake");
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        //Crouch related
        playerCollider = GetComponent<BoxCollider2D>();
        originalSize = playerCollider.size;

        
    }

    
    internal void KillPlayer()
    {
        Debug.Log("Player hit by the Enemy");
        animator.SetBool("Death", true);
        ReloadScene();
    }

    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void PickUpKey()
    {
        Debug.Log("Player picked up the Key");
        scoreController.IncreaseScore(10);
    }
    private void Update()
    {   // PlayerMovement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        MoveCharacter(horizontal, vertical);
        PlayerMovementAnimation(horizontal, vertical);


        //Crouch
        PlayerCrouchAnimation();
    }

    private void MoveCharacter(float horizontal, float vertical)
    {   
        //RunMove
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //JumpMove
        if (vertical > 0)
        {
            rb2D.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
        // RUN
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    
        // Jump
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
    private void PlayerCrouchAnimation()
    {
        animator.SetBool("Crouch", isCrouching);

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            isCrouching = true;
            //playerCollider.size = crouchSize;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            isCrouching = false;
           // playerCollider.size = originalSize;
        }
    }
}
