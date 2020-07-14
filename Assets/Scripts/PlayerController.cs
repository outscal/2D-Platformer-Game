using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
     public Animator animator;

    public ScoreController scoreController;

    public float speed;
    public float jump;
    private new Rigidbody2D rigidbody2D;

     private void Awake()
     {
         Debug.Log("PlayerController Awake");
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
     }
     private void OnCollisionEnter2D(Collision2D collision)
     {
         Debug.Log("Collision :" + collision.gameObject.name);
     }
    public void PickUpkey()
    {
        Debug.Log("Player picked up the key");
        scoreController.IncreaseScore(10);
    }
    public void KillPlayer()
    {
        Debug.Log("Player killed by enemy");
        // Destroy(gameObject);
        ReloadLevel();
    }
    private void ReloadLevel()
    {
        Debug.Log("Reloading the scene");
        SceneManager.LoadScene(0);
    }
     private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal,vertical);
        PlayerMovementAnimation(horizontal,vertical);
    }
    private void MoveCharacter(float horizontal, float vertical) {
        //move Character Horizontally
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //Move Character Vertically
        if (vertical > 0)
        {
            rigidbody2D.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }

    }

    private void PlayerMovementAnimation(float horizontal,float vertical)

    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));

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
        
        if(vertical>0){
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
    }
}