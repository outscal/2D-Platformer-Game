using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField] private float player_speed,player_jump_force;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private LevelController levelController;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private List<GameObject> health_sprites;
    private int player_health = 3;
    bool is_player_grounded = false;
    public float timer = 0;
    private float death_animation_timer = 0.04f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayerMovement(horizontal, vertical);
        PlayerAnimation(horizontal,vertical);
        OutOfBounds();
    }

    //Player Movement
    void PlayerMovement(float horizontal,float vertical)
    {
        //Horizontal Movement
        Vector2 player_position = transform.position;
        player_position.x = player_position.x + horizontal * player_speed * Time.deltaTime;
        transform.position = player_position;
       // Debug.Log(is_player_grounded);
        //Vertical Movement
        if (vertical>0 && is_player_grounded)
        {
            animator.SetTrigger("jump_trigger");
            rb2D.velocity = new Vector2(rb2D.velocity.x, player_jump_force);
            is_player_grounded= false;
        }

    }


    //On Collision Enter
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            //Debug.Log(collision.gameObject.name);
            is_player_grounded=true;
        }
    }

    //On Collision Exit
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            //Debug.Log(collision.gameObject.name);
            is_player_grounded=false;
        }
    }

    //Player Animation
    void PlayerAnimation(float horizontal,float vertical)
    {

        animator.SetFloat("speed",Mathf.Abs(horizontal));

        Vector2 scale = transform.localScale;
        if (horizontal < 0f)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", false);
        }

        if(vertical>0)
        {
            animator.SetBool("jump", true);
        }
        else 
        {
            animator.SetBool("jump", false);

        }


        transform.localScale = scale;
    }


    void OutOfBounds()
    {
        Vector2 y_lower_position = new Vector2(0, -11);
        if(transform.position.y < y_lower_position.y)
        {
            levelController.LevelReload();
        }
    }

   public  void PickupKey()
    {
        Debug.Log("Key is picked");
        scoreController.IncreaseScore(10);
        //timer = Time.time;
        //Debug.Log(timer);
        //key_animator.SetBool("Key_Fade_Out", false);

    }

    public void PlayerKilled()
    {
        if(player_health>=0)
        {
        DecreaseHealth();

        }
        if (player_health<=0)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            animator.SetTrigger("death");
            if(timer>death_animation_timer)
            {
                levelController.LevelReload();
                Debug.Log("Player Died");

            }
        }
    }

    void DecreaseHealth()
    {
        if(player_health>0)
        {
            Destroy(health_sprites[player_health - 1]);
            player_health--;
        }
     
    }
}
