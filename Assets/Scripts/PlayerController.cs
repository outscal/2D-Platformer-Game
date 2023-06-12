using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public float Speed;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        PlayerMvntAnimation(horizontal);
        MoveCharacter(horizontal);
        CrouchAnimation();

    }

    private void CrouchAnimation()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }
    }

    private void PlayerMvntAnimation(float horizontal)
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
        position.x = position.x + horizontal * Speed * Time.deltaTime;
        transform.position = position;


    }
}
