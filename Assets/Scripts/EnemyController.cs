using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform CurrentPoint;
    public float speed;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim =GetComponent<Animator>();
        CurrentPoint = PointB.transform;
        anim.SetBool("Isrunning",true);
    }

    private void Update() 
    {
        Vector2 point = CurrentPoint.position - transform.position;
        if(CurrentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(speed,0);
        }
        else
        {
            rb.velocity = new Vector2(-speed,0);
        }
        if(Vector2.Distance(transform.position,CurrentPoint.position)<0.5f && CurrentPoint  ==PointB.transform)
        {
            transform.localScale = new Vector3(-1,1,1);
            CurrentPoint = PointA.transform;
        }
         if(Vector2.Distance(transform.position,CurrentPoint.position)<0.5f && CurrentPoint  ==PointA.transform)
        {
            transform.localScale = new Vector3(1,1,1);
            CurrentPoint = PointB.transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {

        if(other.gameObject.GetComponent<PlayerControllerScript>() != null)
        {
            anim.SetBool("IsAttacking",true);
        }
        
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.GetComponent<PlayerControllerScript>() != null)
        {
            anim.SetBool("IsAttacking",false);
        }
    }
}
