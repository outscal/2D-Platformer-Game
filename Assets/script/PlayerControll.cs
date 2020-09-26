using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    float sf=0.25f;
    public float fast;
    Rigidbody2D rigidbody;
    BoxCollider2D collider2D;
    public Animator animator;
    float Horizontalspeed;
    public float jump;

    private void Awake(){
        Debug.Log("Player controller");
    }
    private void OnCollisionEnter(Collision collision)

    {
        if (collision is null)
        {
            throw new System.ArgumentNullException(nameof(collision));
        }
       
    }
    private void Start(){
            rigidbody=GetComponent<Rigidbody2D>();
            collider2D=GetComponent<BoxCollider2D>();
    }
    private void Update(){
      
    Horizontalspeed=Input.GetAxisRaw("Horizontal");
    PlayerAnimation(Horizontalspeed);
    //     float X=0.55462f;
    //     float Y=2.2113f;
    //   collider2D.size=new Vector2(X,collider2D.size.x);
    //   collider2D.size=new Vector2(Y,collider2D.size.y);
      PlayerMovementX(Horizontalspeed);
}
private void PlayerAnimation(float horizontal){
animator.SetFloat("speed",Mathf.Abs(horizontal));
    //     //speed=9.0f;
       Vector3 scale =transform.localScale;
         if (horizontal<0){
            
             scale.x=-1f*Mathf.Abs(scale.x);
         }else if(horizontal>0){
             scale.x=Mathf.Abs(scale.x);
         }
         transform.localScale=scale;
        float vericalSpeed=Input.GetAxisRaw("Vertical");
        bool v = Input.GetKeyDown(KeyCode.W);
        bool v2=Input.GetKeyDown(KeyCode.S);
        if(vericalSpeed>0 ){
        animator.SetBool("IsJump",true);
        }
        else if(v2==true){
        animator.SetBool("IsJump",v2);
        }
        else
             animator.SetBool("IsJump",false);
        if(vericalSpeed>0){
            rigidbody.AddForce(new Vector2(0f,jump),ForceMode2D.Force);
        }
}
private void PlayerMovementX(float Horizontalspeed){
    Vector2 positionX=transform.position;
    positionX.x=positionX.x+Horizontalspeed*fast*Time.deltaTime;
    transform.position=positionX;
    
}
 
}