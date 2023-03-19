using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed=1f;
    public Rigidbody2D myBody;
    private Animator myAnim;

    public bool moveright;
    public Transform down_Collison;
    public Transform playerTraget;
    public Vector2 tempScale;
    public bool flagEnter;
    public Transform EnemyPlatform;
    private void Awake()
    {
        flagEnter = false;
        tempScale = transform.localScale;
        moveright = true;
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveright==true)
        {
            myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y);
        }
        else /*if (moveright == false)*/
        {
            myBody.velocity = new Vector3(-moveSpeed, myBody.velocity.y);
        }

        CheckCollisonGround();
        FlipEnemy();

        EnemyAnimation();
    }

    void CheckCollisonGround()
    {     
      
         if (!Physics2D.Raycast(down_Collison.position, Vector2.down, 0.1f))
        {
          //  Debug.Log("ray is Not Casting to ground");
            moveright = !moveright;
        }

        Debug.DrawRay(down_Collison.position, new Vector3(0,0.1f,0),Color.black,Mathf.Infinity);

        //Color.black  // here color struct  have block,white all memeber are static ?

        // Does debug.dray ray tales High processing Power.
        
        }
    

    void FlipEnemy()
    {
         tempScale = transform.localScale; 
        if (moveright == true)
        {
           
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        else if(moveright == false)
        {
            
            tempScale.x = -Mathf.Abs(tempScale.x);
        }

         transform.localScale= tempScale;
    }

    
    void EnemyAnimation()
    {
       
         if(Mathf.Abs(playerTraget.transform.position.x - this.transform.position.x) <= 1f)
        {
           
          
          
          
            myAnim.SetTrigger("Attack");
            
        }

        





        }




}
