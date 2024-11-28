using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private BoxCollider2D boxCol;
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;

    private Rigidbody2D rb2d;

    public float speed;
    public float jump;
   


    bool isGrounded;
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;

    }

    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal,vertical);
        

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            Crouch(true);

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {

            Crouch(false);

        }
       
    }
    public void MovePlayerVertically(float vertical)
    {
        if (vertical > 0 && isGrounded)
        {
            animator.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
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

    private void MoveCharacter(float horizontal,float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal*speed*Time.deltaTime;
        transform.position = position;

        if(vertical>0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
 
        

    }
    private void PlayMovementAnimation(float speed,float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {

            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {

            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;

       
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else 
        {
            animator.SetBool("Jump", false);
        }
    }

    public void Crouch(bool crouch)
    {
        if (crouch == true)
        {
            float offX = -0.0978f;     //Offset X
            float offY = 0.5947f;      //Offset Y

            float sizeX = 0.6988f;     //Size X
            float sizeY = 1.3398f;     //Size Y

            boxCol.size = new Vector2(sizeX, sizeY);   //Setting the size of collider
            boxCol.offset = new Vector2(offX, offY);   //Setting the offset of collider
        }

        else
        {
            //Reset collider to initial values
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }

        //Play Crouch animation
        animator.SetBool("Crouch", crouch);
    }

   
}
    




