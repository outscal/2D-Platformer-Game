using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayerScript : MonoBehaviour
{
    public float speed;
    public Transform originPos;
    // Vector2 dir = new Vector2(0,-1);// for down
    // Vector2 dir = new Vector2(0,1);// for up
    // Vector2 dir = new Vector2(-1,0);// for left
        Vector2 dir = new Vector2(1,0);// for right
    public float range;
    Rigidbody2D rb;

    // int layerMask = 1 << 8;
    // layerMask = ~layerMask;

    // [SerializeField]
    // private LayerMask platformLayerMask;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // if (Input.GetKey(KeyCode.A))
        // {
        //     rb.velocity = new Vector2(-speed, rb.velocity.y);
        // }
        // else if (Input.GetKey(KeyCode.D))
        // {
        //     rb.velocity = new Vector2(speed, rb.velocity.y);
        // }
        // else
        // {
        //     rb.velocity = new Vector2(0, rb.velocity.y);
        // }


        Debug.DrawRay(originPos.position, dir * range);

        RaycastHit2D hit = Physics2D.Raycast(originPos.position, dir, range);
        if (!hit)
        {
            flipDir();
        }


    }

    // void namepp()
    // {
    //     // if (hit)
    //     // {
    //     Debug.Log(hit.collider.name);
    //     // if (hit.collider.tag == "Platform")
    //     // {

    //     //     Flip();
    //     //     speed *= -1;
    //     //     dir *= -1;

    //     // }


    //     // }



    // }

    void flipDir()
    {
        Flip();
        speed *= -1;
        dir *= -1;
    }

    void Flip()
    {
        Vector2 scale = transform.localScale;
        scale.x = -(scale.x);
        transform.localScale = scale;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

}
