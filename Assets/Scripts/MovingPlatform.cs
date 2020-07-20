using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool collided = false;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x += speed * Time.deltaTime;
        transform.position = position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        speed = -1f * speed;
    }
}
