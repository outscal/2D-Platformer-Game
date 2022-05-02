using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{

    public float jump;
    public float speed = 0f;
    public Animator movementanimator;
    // Start is called before the first frame update
    void Start()
    {
        movementanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        movementanimator.SetFloat("speed", Mathf.Abs(horizontalMovement));
        Debug.Log(horizontalMovement);
        Vector2 scale = transform.localScale;
        if (horizontalMovement < 0)
            scale.x = -1f * Mathf.Abs(scale.x);
        else if (horizontalMovement > 0)
            scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
    }


    private void MoveCharacter(float horizontal, float vertical) //character moving function
    {
        //horizontal movements
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime; // [1 / frames per second]
        transform.position = position;

        //vertical movements
        if (vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        movementanimator.SetFloat("speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0) //rotating it for the left animation (flip)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //jump
        if (vertical > 0)
        {
            movementanimator.SetBool("Jump", true);
        }
        else
        {
            movementanimator.SetBool("Jump", false);
        }

    }
}
