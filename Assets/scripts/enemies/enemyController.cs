using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    int speed = 2;
    public int attackforce;
    public float patrollingDistance;// walk range
    public Transform groundDection;
    public Transform spitPos;
    public Transform playerPos;
    public GameObject acidSpit;

    public float runRange, attackRange;
    int direction = 1;
    bool CanSpit = true;
    bool dead = false;
    playerController pc;
    Animator anmi;
    float distance;
    Vector3 position;
    public int spitSpeed;
    private int health = 100;
    public enemyController()
    {

    }
    

    void Start()
    {
       

        anmi = gameObject.GetComponent < Animator >();
        position = transform.position;

    }
    private void Update()
    {
       if(!dead)
        {
            distance = Vector2.Distance(playerPos.position, transform.position);
            if ((distance > 0 && distance <= attackRange) && CanSpit)
            {

                attack();
            }

            if (distance > attackRange && distance < runRange)
            {
                run();
            }
            if (distance > runRange)
            {
                move();
                raycastMove();
            }
        }
                      
       
    }

   
    

    private void move()
    {
       
        anmi.SetInteger("movement", 1);
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
        distance = position.x - transform.position.x;
        if (distance > patrollingDistance)
            turnRight();
        if (distance < -patrollingDistance)
            turnLeft();
    }


    void raycastMove()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDection.position, Vector2.down, 2);
        if (groundInfo.collider == false)
            changeDrirection();
    }
   

    
    private void changeDrirection()
    {
        direction *= 1;
        transform.Translate(new Vector3( -1, 0, 0) );
        transform.Rotate(new Vector3(0, 180 , 0));

    }
    void turnRight()
    {
        direction = 1;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));//turnright
    }
    void turnLeft()
    {
        direction = -1;
        transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));//turn left
    }

    void run()
    {
        
        anmi.SetInteger("movement", 2);
        if (playerPos.position.x < transform.position.x)
            turnLeft();
       else
            turnRight();
        transform.Translate(new Vector3(speed+2, 0, 0) * Time.deltaTime);


    }





private void OnCollisionEnter2D(Collision2D collision)
{
     

        if (collision.gameObject.GetComponent<playerController>() != null && collision.gameObject.CompareTag("Player"))
        {
          
           pc = collision.gameObject.GetComponent<playerController>();
            Vector2 direction = transform.position - pc.gameObject.transform.position;
           
            pc.looseHealth();
           
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-direction *attackforce, ForceMode2D.Impulse);
               
        }
        if (collision.gameObject.CompareTag("spikes"))
            changeDrirection();
}
 
    void attack()
    {
        anmi.SetBool("attack", true);
        StartCoroutine(Spit());
        
       
    }
    public void loseHealth()
    {
        Debug.Log("enemy health" + health);
        health-=25;
        if (health < 0)
            die();
    }


     void die()
    {
        anmi.SetBool("die", true);
        dead = true;
        Destroy(gameObject, 2);

    }
    IEnumerator Spit()
    {
        CanSpit = false;
        soundManager.Instance.Play(Sounds.enemyAttack);
        yield return new WaitForSeconds(1);
        GameObject spit = Instantiate(acidSpit, spitPos.transform.position, Quaternion.identity);
        spit.GetComponent<Rigidbody2D>().velocity = new Vector2(direction * spitSpeed, 1);
        Destroy(spit, 1);
        anmi.SetBool("attack", false);
        CanSpit = true;
    }


    
}
