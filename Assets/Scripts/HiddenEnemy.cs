using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenEnemy : MonoBehaviour
{
    public Animator animator;

    private GameObject player;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxcollider;
    public Vector2 jump;

    public int playerCollided = 0;

    private Vector2 newColliderSize = new Vector2(1.5f,0.8f);
    private Vector2 newColliderOffset = new Vector2(0.03f,0.4f);
    public bool attack;
    private int groundLayer = 9;
    private int movingPlatformLayer = 20;
    private int deathLayer = 13;
    private int walls = 18;
    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        boxcollider = gameObject.GetComponent<BoxCollider2D>();

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            player = other.gameObject;
            playerCollided++;
            attack = true;
            boxcollider.size = newColliderSize;
            boxcollider.offset = newColliderOffset;
            animator.SetBool("attack", true);
            

            if(playerCollided == 2)
            {

                PlayerController player = other.gameObject.GetComponent<PlayerController>();
                if (!other.gameObject.GetComponent<Animator>().GetBool("Died"))
                {
                    player.PlayerDied();
                }
                Destroy(gameObject);
               
            }
            //return;
            
        }

        if(other.gameObject.layer == groundLayer || other.gameObject.layer == movingPlatformLayer)
        {
            if(attack)
            {
                rigidbody.velocity = jump;
                if(Mathf.Abs(transform.position.x - player.transform.position.x) < 30)
                {
                    SoundManager.Instance.PlayMusic(Sounds.ChomperAttack);
                }
                
            }
            //return;
        }

        if (other.gameObject.layer == deathLayer || other.gameObject.layer == walls)
        {
            Destroy(gameObject);
        }

    }

}
