using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float jump = 2.0f;
    public Animator animator;
    private Rigidbody2D Rigid2D;
    private Collision2D collision;
    public ScoreController scoreController;
    private int Health;
    public HealthController healthController;
    public Gameovercontroller gameovercontroller;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        jump = 2.0f;
        //Debug.Log("Collision " + collision.gameObject.name + " " + jump);
        Rigid2D = gameObject.GetComponent<Rigidbody2D>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigid2D.AddForce(new Vector2(-2f, 2f), ForceMode2D.Impulse);
            healthController.TakeDamage();
            animator.SetBool("Hurt", true);
            //Health = healthController.HealthCheck();
            if (healthController.HealthCheck() <= 0)
            {
                gameovercontroller.PlayerDead();
                animator.SetBool("Death", true);
                this.enabled = false;
                //SceneManager.LoadScene(0);
            }
            
            //Debug.Log("Active");
            //animator.SetBool("Death", false);
            //animator.SetBool("PermaDeath", true);
        }
        //DamageCheck();
    }
    private void OnCollisionExit2D()
    {
        jump = 0f;
        //Debug.Log("Jump parameter zeroed " + jump);
        if(healthController.HealthCheck() > 0)
        {
            StartCoroutine(DoSomething(2));
        }
        else
        {

        }
        animator.SetBool("Hurt", false);
    }

    IEnumerator DoSomething(int duration)
    {
       yield return new WaitForSecondsRealtime(duration);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Health = healthController.HealthCheck();
    }

    // Update is called once per frame
    void Update()
    {
        //OnCollisionEnter2D(collision);
        //jumpcheck(collision);
        float speed = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        AnimationMade(speed, vertical);
        Movement(speed, vertical);
        
    }
    void jumpcheck(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            //Debug.Log("Object is colliding");
        }

        /*if (collision.gameObject.tag == "Platform")
        {
            jump = 1.5f;
            Debug.Log("Jump parameter set");
        }
        else if (collision.gameObject.tag != "Platform")
        {
            jump = 0;
            Debug.Log("Jump parameter zeroed");
        }*/

    }
    void Movement(float speed, float vertical)
    {

        Vector3 position = transform.position;
        position.x = position.x + speed * Time.deltaTime;
        transform.position = position;
        if (vertical > 0)
        {
            Rigid2D.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }

    }
    void AnimationMade(float speed, float jumpinput)
    {
        bool Jump = false;
        //float jumpinput = Input.GetAxisRaw("Vertical");
        bool crouch = false;
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (jumpinput > 0)
        {
            Jump = true;
            crouch = false;
        }
        else if (jumpinput == 0)
        {
            Jump = false;
            crouch = false;
        }
        else if (jumpinput < 0)
        {
            Jump = false;
            crouch = true;
        }
        animator.SetBool("Jump", Jump);
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        animator.SetBool("Crouch", crouch);
    }

    internal void PickUpCollectibe()
    {
        //Debug.Log("Player Picked up key");
        scoreController.Scoreup(10);
    }

    void DamageCheck()
    {
        if (collision.gameObject.GetComponent<EnemyController>() != null)
        {
            animator.SetBool("Death", true);

        }
    }
}
