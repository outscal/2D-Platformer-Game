using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour
{
    public PlayerMovement playerMovement; 
    public ScoreController scoreController;
    private GameOverController gameOverController;
    private DeathController deathController;
    private HealthController healthController; 

    public Animator playerAnimator;

    public float runSpeed;   
    private float horizontalMove = 0f;
    public bool jump;
    public bool crouch; 
    
    void Update()
    {
        runAnim(); 
        jumpAnim();
        crouchAnim(); 
    }

    void runAnim()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        playerAnimator.SetFloat("speed", Mathf.Abs(horizontalMove));
    }

    void jumpAnim()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            playerAnimator.SetBool("isJumping", true);
        }
    }

    void crouchAnim()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        // Move our character 
        playerMovement.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false; 
    }

    void deathAnim()
    {
        playerAnimator.SetBool("isDying", true);
    }

    void hurtAnim()
    {
        playerAnimator.SetBool("isHurt", true);
        StartCoroutine(TimedelayForHurting()); 
    }

    public void OnLanding()
    {
        playerAnimator.SetBool("isJumping", false); 
    }

    public void OnCrouching(bool IsCrouching)
    {
        playerAnimator.SetBool("isCrouching", IsCrouching); 
    }


    public void DamagePlayer()
    {
        playerMovement.hurtPlayer();
        hurtAnim();
        healthController.LoseLife();
    }

    public void KillPlayer()
    {
        deathAnim();

        deathController.PlayerDied(); 
        gameOverController.GameOver();  
    }

    public void PickUpKey()
    {
        scoreController.IncreaseScore(1); 
    }

    IEnumerator TimedelayForHurting()
    {
        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("isHurt", false);
    }

}
