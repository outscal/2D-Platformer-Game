using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Animator animator;
   public float speed;
   public float jump;
   

   private Rigidbody2D  rgbd2D;

   private void Awake() {
      Debug.Log("Player Controller awake");
      rgbd2D = gameObject.GetComponent<Rigidbody2D>();
   }
   // private void OnCollisionEnter2D(Collision2D collision) {
   //    Debug.Log("Collision: " + collision.gameObject.name);
   // }

   private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);

    }

    private void MoveCharacter(float horizontal, float vertical){
       //Move Horizontally
        Vector3 position  = transform.position;
        position.x +=  horizontal *speed * Time.deltaTime;
        transform.position = position;

        //Move Vertically
        if(vertical > 0){
            rgbd2D.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
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

        //Jump
        if(vertical > 0){
            animator.SetBool("Jump", true);
        }
        else{
            animator.SetBool("Jump", false);
        }

        //crouch
        if(Input.GetKey(KeyCode.LeftControl)){
            animator.SetBool("isCrouch", true);
        }
        else{
            animator.SetBool("isCrouch", false);
        }
    }
}

     