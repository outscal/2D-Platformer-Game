using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public Animator animator;
    private void Awake(){
        Debug.Log("Player controller");
    }
    private void OnCollisionEnter(Collision collision)

    {
        
        //Debug.Log("collision:"+collision.gameObject.name);
        if (collision is null)
        {
            throw new System.ArgumentNullException(nameof(collision));
        }
       
    }
    private void Update(){
        float speed=Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed",Mathf.Abs(speed));
        Vector3 scale =transform.localScale;
        if (speed<0){
            
            scale.x=-1f*Mathf.Abs(scale.x);
        }else if(speed>0){
            scale.x=Mathf.Abs(scale.x);
        }
        transform.localScale=scale;
    }
}
