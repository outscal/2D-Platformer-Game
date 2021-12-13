using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Animator animator;
  public float speed;
    private void Awake()
    {
        Debug.Log("Player Awake");
    }

    private void Update()
    {
        // Code for keybinding #1 Run
        float horizontal = Input.GetAxisRaw("Horizontal");
       MovementAnimation(horizontal);
       MoveCharacter(horizontal);

        //Code for Keybinding #1.2 Walk/Run Toggle
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            animator.SetTrigger("Walk/Run Toggle");
        }
        else if (Input.GetKeyUp(KeyCode.RightAlt))
        {
            animator.ResetTrigger("Walk/Run Toggle");
        }
        
        // Code for Keybinding #2 crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            animator.SetBool("Crouch", true);
            //Debug.Log("Crouching");


        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {

            animator.SetBool("Crouch", false);
            // Debug.Log("NotCrouching");
        }

        




    }

    private void MovementAnimation(float horizontal)
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
    }

    private void MoveCharacter(float horizontal)
    {
      Vector3 position = transform.position;
      position.x += horizontal * speed * Time.deltaTime;
      transform.position = position;
     }
}
