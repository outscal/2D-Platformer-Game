using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;

    private Rigidbody2D rb2d;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    private void Awake()
    {
        Debug.Log("Player Controller awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
       // SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    private void Update()
    {   
       
         float horizontal = Input.GetAxisRaw("Horizontal"); //For static Movement
         float vertical = Input.GetAxisRaw("Jump");

         MoveCharecter(horizontal,vertical);
         PlayMovementAnimation(horizontal,vertical);
    }

        private void MoveCharecter (float horizontal,float vertical) {
          // move char Horizontally
          Vector3 position = transform.position;
          position.x += horizontal * speed * Time.deltaTime;
          transform.position = position;

          // move char Vertically
          if (vertical > 0)
          {
              rb2d.AddForce(new Vector2(0f,jump), ForceMode2D.Force);

          }




        }

        private void PlayMovementAnimation(float horizontal,float vertical)
        {
         animator.SetFloat("Run", Mathf.Abs(horizontal));
         Vector3 scale = transform.localScale;
        if (horizontal < 0){
            scale.x = -1f * Mathf.Abs(scale.x);
        } else if (horizontal > 0)
        {
         scale.x =  Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        
         // jump animation
        if (vertical > 0){
            animator.SetBool("Jump",true);
        } else {
             animator.SetBool("Jump",false);
        }
        
        
       }
      
    


}
