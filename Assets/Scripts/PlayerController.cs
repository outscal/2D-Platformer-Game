using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float force;
    public bool IsPlayerGrounded;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        MoveCharachtar(horizontal);
        PlayMovementAnimation(horizontal);

        float vertical = Input.GetAxisRaw("Vertical");
        if (IsPlayerGrounded == true)
        {
            JumpPlayer(vertical);
        }
       

    }

    private void MoveCharachtar(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void JumpPlayer(float vertical)
    {
        Vector3 position = transform.position;
        position.y += vertical * force * Time.deltaTime;
        transform.position = position;
    }


    private void PlayMovementAnimation(float horizontal)
    {
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

        bool crouch = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("Crouch", crouch);

        //float jump = Input.GetAxisRaw("Vertical");
        //animator.SetFloat("Jump", jump);


        //bool jump = Input.GetKey(KeyCode.Space);
        //animator.SetBool("JumpTriggered", jump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("GROUND"))
        {
            IsPlayerGrounded = true;
        }
        else
        {
            IsPlayerGrounded = false;
        }


        if (collision.gameObject.CompareTag("NextLevelTeleporter"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

  

}
