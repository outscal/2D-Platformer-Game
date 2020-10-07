using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Animator animatorEnemy;
    public float moveSpeed=3f;
    Transform leftPoint,rightPoint;
    Vector3 localScale;
    bool movingRight=true;
    Rigidbody2D rigidbody2;
    private void Awake(){
        rigidbody2=GetComponent<Rigidbody2D>();
        localScale=transform.localScale;
        leftPoint=GameObject.Find("leftPoint").GetComponent<Transform>();
        rightPoint=GameObject.Find("rightPoint").GetComponent<Transform>();
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.GetComponent<PlayerControll>()!=null){
            PlayerControll playerControll=collision.gameObject.GetComponent<PlayerControll>();
            playerControll.KillPlayer();
           
             }
         }
         private void Update(){
             if(transform.position.x>rightPoint.position.x){
                 movingRight=false;
             }
             if(transform.position.x<leftPoint.position.x){
                 movingRight=true;
             }
             if(movingRight){
                 moveRight();
             }
             else
                 moveLeft();

         }
         private void moveRight(){
             movingRight=true;
             localScale.x=1;
             transform.localScale=localScale;
             rigidbody2.velocity=new Vector2(localScale.x*moveSpeed,rigidbody2.velocity.y);
         }
         private void moveLeft(){
             movingRight=false;
             localScale.x=-1;
             transform.localScale=localScale;
             rigidbody2.velocity=new Vector2(localScale.x*moveSpeed,rigidbody2.velocity.y);
         }
    
    }
