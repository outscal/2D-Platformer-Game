using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    public Transform grounddetection;
    Rigidbody2D E_RB2D;
    private void Start()
    {
        E_RB2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(IsFacingRight())
        {
            E_RB2D.velocity = new Vector2(speed, 0f);
        }
        else
        {
            E_RB2D.velocity = new Vector2(-speed, 0f);
        }
    }
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.localScale = new Vector2(-(Mathf.Sign(E_RB2D.velocity.x)), transform.localScale.y);
        }
    }
}
        
