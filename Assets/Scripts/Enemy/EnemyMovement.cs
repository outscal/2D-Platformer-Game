using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float speed;
    [SerializeField]  float distance;
    private bool movingRight = true;
    [SerializeField] Transform groundDetection;
    [SerializeField] int maxHealth = 100;
    // private GameObject bloodSplash;
     
    
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(!groundInfo.collider)
        {
            if(movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else if(!movingRight) 
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        
    }
    public void TakeDamage(int damage)
    {
        maxHealth -= damage;
        if(maxHealth <= 0)
        {
            EnemyDie();
             Destroy(gameObject,0.2f);
          

        }
    }

    void EnemyDie()
    {
         //Instantiate(bloodSplash, transform.position, Quaternion.identity);
        SoundManager.Instance.Play(Sounds.EnemyDeath);
        animator.SetTrigger("Dead");
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        

    }
}
