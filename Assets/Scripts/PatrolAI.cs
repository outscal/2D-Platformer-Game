using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;

    public float speed;  
    public Transform GroundDetection;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
            RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.right, 0.1f);
            if(groundInfo.collider == true)
            {
                Flip();
            }
            RaycastHit2D groundInfo02 = Physics2D.Raycast(GroundDetection.position, Vector2.down, 2f);
            if (groundInfo02.collider == false)
            {
                Flip();
            }
        }
    }

    public void Patrol()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        animator.SetFloat("Speed", 0.4f);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        mustPatrol = true;
    }
}
