using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    float movespeed = 1f;
    Rigidbody2D myrigidbody;
    //BoxCollider2D boxCollider;

    public void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if(isFacingRight())
        {
            myrigidbody.velocity = new Vector2(movespeed, 0f);
        }
        else
        {
            myrigidbody.velocity = new Vector2(-movespeed, 0f);
        }
    }
    private bool isFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myrigidbody.velocity.x)), transform.localScale
            .y);
    }
}
