using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{

    public GameObject player;
    public float player_speed;
    public Animator animator;
    public Rigidbody2D rb;
    public int jump_distance;
    public bool has_jumped=true;
    public int last_direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        move_animation(speed);
        movement(speed);
        jump();
        //player.transform.localScale = new Vector3(speed, player_speed, 0);
    }
    private void move_animation(float speed)
    {
        if (!has_jumped)
        {
            Debug.Log(speed);
            animator.SetFloat("Speed", Mathf.Abs(speed));
            if (speed < 0)
            {
                Vector2 Scale = transform.localScale;
                Scale.x = -1;
                transform.localScale = Scale;
                last_direction = -1;
            }
            else if (speed > 0)
            {
                Vector2 Scale = transform.localScale;
                Scale.x = 1;
                transform.localScale = Scale;
                last_direction = 1;
            }
            if (Input.GetKey("left ctrl"))
            {
                animator.SetBool("Crouched", true);
            }
            else
            {
                animator.SetBool("Crouched", false);
            }
        }
    }
    
    private void movement(float speed)
    {
        if (!has_jumped)
        {
            Vector2 pos = new Vector2(transform.position.x + speed * player_speed * Time.deltaTime, transform.position.y);
            transform.position = pos;
        }
    }

    private void jump()
    {
        if(has_jumped)
        {
            animator.SetBool("Jump", false);
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && !has_jumped)
        {
            rb.AddForce(new Vector2(jump_distance*last_direction,jump_distance));
            animator.SetBool("Jump",true);
            has_jumped = true;
            //
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="Ground")
        {
            has_jumped = false;
        }
    }
}
