using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playercontroller : MonoBehaviour
{
    public  Animator animator;
    private void Awake()
    {
        Debug.Log("I AM ON");
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("I AM collided"+ collision.gameObject.name);
    //}

    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        Vector3 scale = transform.localScale;
        animator.SetFloat("Speed", Mathf .Abs( speed));
        if (speed < 0)
        {
            
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0) { 
        
          scale.x= Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }
}
