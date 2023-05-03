using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public float jump;
    private Rigidbody2D playerRb;

    private void Awake()
    {
        playerRb= GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        
        PlayMovementAnimation(horizontal, vertical);
        PlayerMovement(horizontal, vertical);

        
    }
    public void PlayMovementAnimation(float horizontal, float vertical)
    {
        //For jump
        anim.SetFloat("Speed", Mathf.Abs(horizontal));
        if (vertical > 0)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }

        //Turning Character
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(horizontal);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(horizontal);
        }
        transform.localScale = scale;

        //For crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("Crouch", true);
        }
        else
        {
            anim.SetBool("Crouch", false);
        }
    }

    public void PlayerMovement(float horizontal, float vertical)
    {
        //Horizontal movement
        Vector3 temp = transform.position;
        temp.x += horizontal * speed * Time.deltaTime;
        transform.position = temp;

        //Vertical movement
        playerRb.AddForce(Vector2.up * jump * vertical, ForceMode2D.Impulse);
    }
}
