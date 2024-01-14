using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private CircleCollider2D pointA;
    [SerializeField] private CircleCollider2D pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform PointToGoTo;
    [SerializeField] private float speed;
    bool playerDied;
    bool switchUP;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PointToGoTo = pointB.transform;
        anim.SetBool("Walking", true);
        playerDied = false;
        switchUP = false;

    }


    // Update is called once per frame
    void Update()
    {
        if(!playerDied)
        {
            if(PointToGoTo == pointB.transform)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }

            if (switchUP && PointToGoTo == pointB.transform)
            {

                //StartCoroutine(WaitAtEdge());
                //Debug.Log("Flipped towards B");
                flip();
                switchUP = false;
                PointToGoTo = pointA.transform;
                Debug.Log("Point to go to swithced to A");

            }

            if (switchUP && PointToGoTo == pointA.transform)
            {

                //StartCoroutine(WaitAtEdge());
                //Debug.Log("Flipped towards A");
                flip();
                switchUP = false;
                PointToGoTo = pointB.transform;
                Debug.Log("Point to go to swithced to B");
            }


        }
        
    }

    private void flip()
    {
        Vector2 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }

    //IEnumerator WaitAtEdge()
    //{
    //    Debug.Log("Waiting at edge");
    //    anim.SetBool("Walking", false);
    //    yield return new WaitForSeconds(2);
    //    anim.SetBool("Walking", true);
    //}

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("Enenmy collision : " + col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            PlayerController Cont = col.gameObject.GetComponent<PlayerController>();
            playerDied = true;
            anim.SetBool("Walking", false);
            Cont.KillPlayer();
                
        }

        if(col.gameObject.tag == "pointA" || col.gameObject.tag == "pointB")
        {
            switchUP = true;

        }

    }

}
