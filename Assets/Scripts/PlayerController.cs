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
    public float speed;
    private float jumpForce;
    public float jumpHeight = 0.2f;
    public bool isGrounded;
    public Vector2 crouchedColliderScale = new Vector2(0.9171886f, 1.328003f);
    public Vector2 crouchedColliderOffset = new Vector2(-0.11f, 0.59f);
    public GameObject levelStart;
    public GameObject mainCamera;
    public int health = 3;
    public Image[] hearts;
    public GameObject deathUIPanel;
    private BoxCollider2D _collider;
    private Vector2 _standingColliderScale, _standingColliderOffset;
    private bool _isJumping = false;
    private Rigidbody2D rigidbodyPlayer;
    
    private bool isdead;
    

    private void Awake()
    {
        rigidbodyPlayer= gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _standingColliderScale = _collider.size;
        _standingColliderOffset = _collider.offset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool crouch = Input.GetKey(KeyCode.LeftControl);

        if(isdead == false){
            PlayMovementAnimation(horizontal,vertical,crouch);
            PlayerMovementFunction(horizontal,vertical,crouch);
        }

        if(transform.position.y < -20f){
            transform.position = levelStart.transform.position;
            Debug.Log("Level Restarted!");
        }        
    }

    private void PlayMovementAnimation(float horizontal, float vertical, bool crouch){
        if(crouch)
        {
            _collider.size = crouchedColliderScale;
            _collider.offset = crouchedColliderOffset;
        }
        else
        {
            _collider.size = _standingColliderScale;
            _collider.offset = _standingColliderOffset;
        }

        animator.SetBool("Crouch", crouch);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        animator.SetFloat("Vertical", Mathf.Abs(vertical));

        Vector3 scale = transform.localScale;

        if (horizontal < 0){
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if(horizontal > 0){
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (vertical > 0 && !_isJumping)
        {
            Debug.Log(vertical);
            animator.SetTrigger("Jump");
            _isJumping = true;
        }

        if(_isJumping)
            _isJumping = !animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Jump");
    }

    private void PlayerMovementFunction(float horizontal, float vertical, bool crouch){
        // Horizontal Movement
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        // Jump Movement
        if (vertical > 0  && isGrounded)
        {
            jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rigidbodyPlayer.gravityScale));
            rigidbodyPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.transform.tag == "platform")
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

    public void GetKey()
    {
        scoreController.increaseScore(10);
    }

    public void DecreaseHealth()
    {
        health--;
                HandleHealthUI();
        if(health <= 0)
            {
                PlayDeathAnimation();
                PlayerDeath();            
            } 
        else
            {
                transform.position = levelStart.transform.position;
            }
    }

    public void PlayerDeath()
    {
        isdead = true;
        mainCamera.transform.parent = null;
        deathUIPanel.gameObject.SetActive(true);
        rigidbodyPlayer.constraints = RigidbodyConstraints2D.FreezePosition;
        rigidbodyPlayer.GetComponent<BoxCollider2D>().isTrigger = true; // Turning off the player collision when dead!
        //ReloadLevel();				
    }

    public void PlayDeathAnimation()
    {
        animator.SetTrigger("Die");
    }

    // private void ReloadLevel()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }

    public void HandleHealthUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
                hearts[i].color = i < health ? Color.red : Color.black;
        }
    }
}
