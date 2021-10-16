using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private void Awake()
    {
    Debug.Log("Player controller awake");    
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //  Debug.Log("Collision:" + collision.gameObject.name);  
    // }

    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale= transform.localScale;
          
        
         if(speed<0){
            scale.x = -1;
        }
        else if(speed>0){
            //scale.x = Mathf.Abs(scale.x);
            scale.x = 1;
        }
        transform.localScale = scale;
    }
}
