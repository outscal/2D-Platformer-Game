using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject player;
    Collider2D enemyCollider;
    Collider2D playerCollider;
    public float speed;
    public float flip = 1 ;
    public float enemyDamage;
    bool isAttacking = false;


    private void Start()
    {
        GetComponent<Animator>().SetFloat("speed", speed);
    }

    private void Update()
    {
        if (isAttacking)
            attack();
        if(!isAttacking)
        walkToAndFro();

    }

    void walkToAndFro()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime*Mathf.Sign(Mathf.Sin(Mathf.PI*Time.time)));
        flip =  Mathf.Sign(Mathf.Sin( Mathf.PI * Time.time));
        transform.localScale = new Vector2(flip, 1);
        GetComponent<Animator>().SetFloat("speed", speed);
    }

    
    void attack()
    {
        GetComponent<Animator>().SetFloat("speed", 0);
    }

    void giveDamage()
    {
        player.GetComponent<PlayerController>().playerHealth -= enemyDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
         isAttacking = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            isAttacking = false;
    }
}
