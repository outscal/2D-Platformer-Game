using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private float moveSpeed=1f;
    private Rigidbody2D myBody;
    private Animator myAnim;

    public bool moveright;
    public Transform down_Collison;
    public Transform playerTraget;
    private Vector2 tempScale;
    private bool flagEnter;
    // public Transform EnemyPlatform;
    public Transform left_Collision, top_Collision, right_Collision;
    public Vector3 left_CollsionPositon, right_CollsionPositon;
    private bool canMove;
    public LayerMask playerLayer;
    private bool dead;
    private PlayeHealth playerHealth;
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

        }

  
    }

    void CheckCollisonGround()
    {

        RaycastHit2D leftHit = Physics2D.Raycast(left_Collision.position, Vector2.left, 0.2f, playerLayer);

        RaycastHit2D righttHit = Physics2D.Raycast(right_Collision.position, Vector2.right, 0.2f, playerLayer);
        Collider2D topHit = Physics2D.OverlapCircle(top_Collision.position, 0.2f);
         
       
        

        if (topHit != null)
        {
            if (topHit.gameObject.GetComponent<PlayerController>()==true)
            {
                print("Inside the enemy Top Collison");
                SoundManager.Instance.PlaySounds(Sounds.EnemyDeath);
                topHit.gameObject.GetComponent<Rigidbody2D>().velocity =
                    new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x,8f);
                canMove = false;
                myBody.velocity = new Vector2(0, 0);
                myAnim.Play("Dead");
                dead = true;
            }


        }

        if (leftHit ==null)
        {
            // why leftHit==true & lefthit==false not showing errro But 
            // why lefthit==null OR lefthit!=null ; showing an squiggly line with a warning == "The result of this expression is always false, since the value of type *bool* is never"
            // equasl to *null* of type bool
            if (!dead)
            {
                if (leftHit.collider.gameObject.GetComponent<PlayerController>())  //  why compare tag is better than gameObject.tag  , i think both are doing string comparision?
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
            if (righttHit.collider.gameObject.GetComponent<PlayerController>() && !dead)
            {
                Debug.Log("Dame By RightHit >>");
                // Apply Dmage
                myAnim.SetTrigger("Attack");
                

                playerHealth.Playerdamage(-1);
            }
            else
            {
               
                myBody.velocity = new Vector2(15f, myBody.velocity.y);
            }

        }
        if (!Physics2D.Raycast(down_Collison.position, Vector2.down, 0.1f))
        {
         
            moveright = !moveright;
        }

        Debug.DrawRay(down_Collison.position, new Vector3(0,0.1f,0),Color.black,Mathf.Infinity);

      

        
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
