using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMuzzles : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public Vector2 jump;
    private int grounLayer = 9;
    private int turnPoint = 19;

    

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == grounLayer)
        {
            Debug.Log("collided");
            rigidbody.velocity = jump;
        }

        if(other.gameObject.GetComponent<MovingMuzzles>()!=null)
        {
            jump.x = -1f * jump.x;
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == turnPoint)
        {
            Debug.Log("collded");
            Vector2 position = jump;
            position.x = -1f * position.x;
            jump = position;
        }
    }


}
