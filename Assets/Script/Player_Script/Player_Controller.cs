using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Controller : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCol;
    [SerializeField] private Rigidbody2D rig2D;
   

    [SerializeField] public Score_Controller scoreController;
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;
    [SerializeField] public float speed;
    [SerializeField] public float jump;

    private bool isGrounded = false;

    [Header("Ground Check Settings")]
    [SerializeField] private LayerMask groundLayer;

    [Header("Scale The Ground Collider")]
    [SerializeField] private Vector2 boxSize = new Vector2(0.6f, 0.1f);
    [SerializeField] private Vector2 boxOffset = new Vector2(0f, -1.1f);
    
    private void Start()
    {
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
    }
    private void Awake()
    {
        Debug.Log("Player Controller Awake");

    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        bool isCrouch = Input.GetKey(KeyCode.LeftControl);



        PlayerMoveAnim(horizontal);
        PlayerJumpAnim();
        CracterMove(horizontal, vertical);
        PlayCrouchAnim(isCrouch);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox((Vector2)transform.position + boxOffset, boxSize, 0f, groundLayer);
    }
    public void CracterMove(float horizontal, float vertical)
    {
        Vector2 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;

        transform.position = position;

        if (vertical > 0 && isGrounded)
        {
            rig2D.velocity = new Vector2(rig2D.velocity.x, 0f); 
            rig2D.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }
    public void PlayerMoveAnim(float horizontal)
    {
        playerAnimator.SetFloat("horizontal", Mathf.Abs(horizontal));

        Vector2 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    public void PlayerJumpAnim()
    {
        if (!isGrounded)
        {
            playerAnimator.SetBool("Jump", true);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
        }

    }

    public void PlayCrouchAnim(bool isCrouch)
    {
        if (isCrouch == true)
        {
            float offX = -0.0978f;
            float offY = 0.5947f;

            float sizeX = 0.6988f;
            float sizeY = 1.3398f;

            boxCol.size = new Vector2(sizeX, sizeY);
            boxCol.offset = new Vector2(offX, offY);

        }
        else
        {

            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }

        playerAnimator.SetBool("Crouch", isCrouch);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((Vector2)transform.position + boxOffset, boxSize);
    }
    public void PickUpKey()
    {
        scoreController.UpdateScore(10);

    }
    public Rigidbody2D GetRigBody() { return rig2D; }

}
