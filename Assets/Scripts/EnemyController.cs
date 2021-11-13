using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public float distance;
    private bool movingRight = true;
    private bool attack;
    public Transform groundDetection;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
            attack = true;
            EnemyAnimation(speed,attack);
        }
    }
    private void Update()
    {
        EnemyMovement(speed,distance);
        EnemyAnimation(speed,attack);
    }
    private void EnemyAnimation(float speed,bool attack)
    {
        //Enemy Movement Animation
        animator.SetFloat("AnimSpeed", speed);
        
        //Enemy Attack Animation
        if(attack==true)
        {
            animator.SetBool("AnimImpact",true);
        }
        else
        {
            animator.SetBool("AnimImpact", false);
        }
    }
    private void EnemyMovement(float speed, float distance)
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0,-180,0);
                movingRight=false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight = true;
            }
        }
    }
}
