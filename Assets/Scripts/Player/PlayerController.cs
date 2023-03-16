using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerSpeed;

     Animator playerAnim;
     Vector3 temp;
    float verticleInput; 
     Collider2D playerCollider;
     Vector2 OriginalCollideSize = new Vector2(0.4f, 2f), OriginalOffset = new Vector2(-0.004f, 0.96f);
     Vector2 CrouchCollideSize = new Vector2(0.58f, 1.31f), CrouchOffset = new Vector2(-0.004f, 0.6f);//Vector2(-0.004f,0.6f)
    float verticleSpeed;
    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();// differnce in colider2D vs BoxColider 2D?
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Vertcile Input..................
        verticleSpeed = Input.GetAxis(HelperNames.VerticalAxis);
        PlayerMove();
      //  Debug.Log(playerSpeed);
        Crouch();
        PlayerJump(verticleSpeed);

        
    }


    public void PlayerMove()
    {
      
        playerSpeed = Input.GetAxis(HelperNames.HorizontalAxis);

        playerAnim.SetFloat("Speed", Mathf.Abs(playerSpeed));
        // Flip Player Left Right.......

        temp = this.transform.localScale;
        if (playerSpeed > 0)
        {
            temp.x = Mathf.Abs(temp.x);
        }
        else if (playerSpeed < 0)
        {
            temp.x = -1f * Mathf.Abs(temp.x);
        }

        this.transform.localScale = temp;


    }


    public void PlayerJump(float VerticleSpeed)
    {
        if(VerticleSpeed>0)
        playerAnim.SetBool("Jump",true);
        else{
            playerAnim.SetBool("Jump", false);
        }
    }
   
    public void Crouch()
    {
        Vector2 SizeColl = playerCollider.bounds.size;
       Vector2 Offset = playerCollider.bounds.size;
       
        if (Input.GetKey(KeyCode.LeftControl))  // are all the key enum parameters in unity ??
        {
            SizeColl.x = CrouchCollideSize.x;
            SizeColl.y = CrouchCollideSize.y;
            playerCollider.bounds.size.Set(SizeColl.x, SizeColl.y, 0);
           
            Offset = CrouchOffset;
            playerCollider.offset.Set(Offset.x, Offset.y);


          //  Debug.Log("After_Sie>>" + playerCollider.bounds.size + "After_Offset>>" + playerCollider.bounds.size);

            playerAnim.SetBool("Crouch",true);
        }
        else
        {

            SizeColl = OriginalCollideSize;
            Offset = OriginalOffset;
           / /Debug.Log("Before_Sie>>" + SizeColl + "Before_Offset>>" + Offset);
            playerAnim.SetBool("Crouch", false);
        }


    }

    public void Run()
    {

        
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Name Printing>>");
        }
    }


}
