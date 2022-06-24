using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPatrol : MonoBehaviour
{
   public float raylenght;
    public float moveSpeed;
    private bool moveRight;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
      [SerializeField]private AudioSource EnenmyAttackSound;
      

    public Transform contactChecker;
    // Start is called before the first frame update
    void Start()
    {
        moveRight = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if(PlayerHealth.gameOver)
        {
            //animator.enabled = false;
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }

        canAttack += Time.deltaTime; 
           

        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (attackSpeed<= canAttack)
            {
                 other.gameObject.GetComponent<PlayerController>().PlayerDamaged(attackDamage);
                 EnenmyAttackSound.Play();
                 canAttack = 0f;
                
            }
            // else
            // {
            //     canAttack += Time.deltaTime;
            // }
            
        }
    }

    private  void FixedUpdate()
    {
            int layerMask = 1 << 7;
        layerMask = ~layerMask;
                    
        RaycastHit2D contactCheck = Physics2D.Raycast(contactChecker.position, Vector2.down, raylenght,layerMask);
        Debug.DrawRay(contactChecker.position, Vector2.right * raylenght, Color.red);

        if (contactCheck == false)
        {
            if(moveRight == true)
            {
                transform.eulerAngles = new Vector2(0, -180);
                
                moveRight = false;
            }
            else
            {
                
                transform.eulerAngles = new Vector2(0, 0);
                moveRight = true;

            }
        }
    }
}
