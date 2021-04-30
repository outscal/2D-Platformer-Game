using System.Xml;
using System.Transactions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playergo : MonoBehaviour
{
   public Animator animator;
   public float speed;
    // Start is called before the first frame update
     private void Awake() 
    {
       Debug.Log("Player Controller Awake"); 
    }
    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        MoveCharacter(horizontal);
        PlayAnimation(horizontal);
     }

     private void MoveCharacter(float horizontal)
     {
      Vector3 position = transform.position; 
      position.x = position.x + horizontal * speed * Time.deltaTime;
      transform.position = position;
     }

     public void PlayAnimation(float horizontal)
     {
        animator.SetFloat("Speed", Math.Abs(horizontal));
          Vector3 scale = transform.localScale;
          if(horizontal<0)
          {
          scale.x = -1f * Mathf.Abs(scale.x);
          }
          else if(horizontal > 0)
          {
              scale.x = Mathf.Abs(scale.x);
          }
              transform.localScale = scale;

             Input.GetAxisRaw("Vertical");
             Input.GetKeyDown(KeyCode.Space);
     }
}
