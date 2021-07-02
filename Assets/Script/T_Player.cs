using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D boxcollider2d;
    public float speed = 6f;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        boxcollider2d = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        PlayerMovement(horizontal, vertical);
    }

    private void PlayerMovement(float horizontal, float vertical)
    {
        //horizontal movement
        Vector2 currentPosition = transform.position;
        currentPosition.x += speed * horizontal *Time.deltaTime;
        transform.position = currentPosition;

    }
}

