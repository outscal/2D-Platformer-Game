using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrolnew : MonoBehaviour
{
    public Animator animator;
    public float race;
    public float jump;
    //creating a local variable linked to Jump force
    // public manually drag // private mein code defines it 
    public Rigidbody2D rb2d;

    private void Update()
    {
        //speed after float can take any name and Horizontal is used to move player in Unity backend
        float speed = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        
        MoveCharacter(speed, vertical);
        playermovementanimation(speed, vertical);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }
        //As jump is already in Unity Backend

        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void MoveCharacter(float speed, float vertical)
    {
        //move char. horizontally
        Vector3 position = transform.position;
        position.x = position.x + speed * race * Time.deltaTime;
        transform.position = position;

        //move char. vertically
        if (vertical>0)
        {
            rb2d.AddForce(new Vector2(0, jump), ForceMode2D.Force);
        }
    }

        //Extracted code from above
        private void playermovementanimation(float speed, float vertical)
        {
            animator.SetFloat("speed", Mathf.Abs(speed));
            Vector3 scale = transform.localScale;
            if (speed < 0)
            {
                scale.x = -1 * Mathf.Abs(speed);
            }
            else if (speed > 0)
            {
                scale.x = Mathf.Abs(speed);
            }
            transform.localScale = scale;
        }
    }
