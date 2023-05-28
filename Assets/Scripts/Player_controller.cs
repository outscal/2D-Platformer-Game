using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_controller : MonoBehaviour
{
    public GameObject player;
    public float player_speed;
    public Animator animator;
    public Rigidbody2D rb;
    public int jump_distance;
    public bool has_jumped=true;
    public int last_direction = 1;
    public enum playerstate {alive,dead};
    public playerstate state = playerstate.alive;
    public bool isdead = false;
    public Transform spawn_p;
    public GameObject player_prefab;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Dead", false);
        spawn_p = GameObject.Find("Respawn box").GetComponent<Transform>();
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
            //Debug.Log(speed);
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

    public void ifdead()
    {
        if(state==playerstate.alive)
        {
            state =playerstate.dead;
           // isdead = true;
            animator.SetBool("Dead",true);
            new WaitForSeconds(5.0f);
            state = playerstate.alive;
            animator.SetBool("Dead", false);
            lives_system.lives_decrease();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            reset_player_on_death();
        }
    }
    public void reset_player_on_death()
    {
        Vector3 spawn_point = spawn_p.position;
        //Destroy(this.gameObject);
        gameObject.transform.position= spawn_point;
        //Instantiate(player_prefab, spawn_point, Quaternion.identity);
    }
}
