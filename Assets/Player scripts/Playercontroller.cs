using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private void Awake()
    {
        Debug.Log("I AM ON");
    }


    private void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        playeranimationhorizontal(horizontal);

        Playercrouchlogic();

        Playerjumplogic();

        Playermovementlogic(horizontal);

    }

    private void Playermovementlogic(float horizontal)
    {

        Vector2 position = transform.localPosition;

        position.x = position.x + speed * horizontal * Time.deltaTime;

        transform.localPosition = position;

    }

    private void Playerjumplogic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jump");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.ResetTrigger("jump");
        }
    }

    private void Playercrouchlogic()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            animator.SetBool("iscrouch", true);

        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {


            animator.SetBool("iscrouch", false);
        }
    }

    private void playeranimationhorizontal(float horizontal)
    {
        Vector3 scale = transform.localScale;
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (horizontal < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);

        }
        else if (horizontal > 0)
        {

            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }




}
