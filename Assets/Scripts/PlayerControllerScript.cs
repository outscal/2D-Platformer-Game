using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public Animator animator; 

    // Update is called once per frame
    void Update()
    {
       float  speed = Input.GetAxisRaw("Horizontal");
       animator.SetFloat("Speed",Mathf.Abs(speed));

       Vector3 resize = transform.localScale;
       if(speed < 0)
       {
        resize.x = -1f * Mathf.Abs(resize.x);
       }
       else if(speed > 0)
       {
        resize.x =Mathf.Abs(resize.x);
       }
       transform.localScale = resize;
   
    }
};    