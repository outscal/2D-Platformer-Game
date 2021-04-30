using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
   public Animator animator;
   public float speed;
    // Start is called before the first frame update
     private void Awake() {
       Debug.Log("Player Controller Awake"); 
    }
    // Update is called once per frame
    private void Update()
    {
          float horizontal = Input.GetAxisRaw("Horizontal");
          animator.SetFloat("Speed", Mathf.Abs(horizontal));
         //if(speed = 0)
          Vector3 scale = transform.localScale;
          if(horizontal<0){
          scale.x = -1f * Mathf.Abs(scale.x);}
          else if(horizontal > 0){
              scale.x = Mathf.Abs(scale.x);}
              transform.localScale = scale;
          
    }
}
