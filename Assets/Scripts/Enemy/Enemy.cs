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
   // public Transform EnemyPlatform;
    public Transform left_Collision, top_Collision, right_Collision;
    public Vector3 left_CollsionPositon, right_CollsionPositon;
    public bool canMove;
    public LayerMask playerLayer;
    public bool dead;
    public PlayeHealth playerHealth;
    private void Awake()
    {
        flagEnter = false;
        tempScale = transform.localScale;
        moveright = true;
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
       left_CollsionPositon = left_Collision.localPosition;
       right_CollsionPositon = right_Collision.localPosition;
        
    }
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (moveright == true)
            {
                myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y);
            }
            else 
            {
                myBody.velocity = new Vector3(-moveSpeed, myBody.velocity.y);
            }

            CheckCollisonGround();
            FlipEnemy();

           // EnemyAnimation();
        }

        Debug.DrawRay(right_CollsionPositon, new Vector3(0.2f, 0, 0), Color.red, Mathf.Infinity);
        Debug.DrawRay(left_CollsionPositon, new Vector3(0.2f, 0, 0), Color.red, Mathf.Infinity);
    }

    void CheckCollisonGround()
    {

        RaycastHit2D leftHit = Physics2D.Raycast(left_Collision.position, Vector2.left, 0.2f, playerLayer);
        // what it will return? if bool then why leftHit Type is not bool?
        RaycastHit2D righttHit = Physics2D.Raycast(right_Collision.position, Vector2.right, 0.2f, playerLayer);
        Collider2D topHit = Physics2D.OverlapCircle(top_Collision.position, 0.2f);
         
       
        // Overlap Circle vs OverlapCircleAll ?

        if (topHit != null)
        {
            if (topHit.gameObject.tag == "Player")
            {
                topHit.gameObject.GetComponent<Rigidbody2D>().velocity =
                    new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x,8f);
                canMove = false;
                myBody.velocity = new Vector2(0, 0);
                myAnim.Play("Dead");
                dead = true;
            }


        }

        if (leftHit)
        {
            // Return value of Physics2D.Raycast is RaycastHit2D object then why letHit and RightHit is boolean?
            if (!dead)
            {
                if (leftHit.collider.gameObject.tag == "Player")
                {
                    // Apply Dmage
                    Debug.Log("Dame By LeftHit >>");
                    myAnim.SetTrigger("Attack");
                  
                  
                    playerHealth.Playerdamage(-1);
                }
            }
           
            else
            {
                Debug.Log("Right Hit Detected >>" + dead);
                myBody.velocity = new Vector2(15f, myBody.velocity.y);
            }

        }
        if (righttHit)
        {
            if (righttHit.collider.gameObject.tag == "Player" && !dead)
            {
                Debug.Log("Dame By RightHit >>");
                // Apply Dmage
                myAnim.SetTrigger("Attack");
                Debug.Log("Atatcjkk Distance==" + Mathf.Abs(playerTraget.transform.position.x - this.transform.position.x));

                playerHealth.Playerdamage(-1);
            }
            else
            {
                Debug.Log("Right Hit Detected >>" + dead);
                myBody.velocity = new Vector2(15f, myBody.velocity.y);
            }

        }
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

            left_Collision.localPosition = left_CollsionPositon;
            right_Collision.localPosition = right_CollsionPositon;
        }
        else if(moveright == false)
        {
            
            tempScale.x = -Mathf.Abs(tempScale.x);
           left_Collision.localPosition = right_CollsionPositon;
          right_Collision.localPosition = left_CollsionPositon;
        }

         transform.localScale= tempScale;
    }

    
  
       
      


}
