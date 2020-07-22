using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenEnemy : MonoBehaviour
{
    public Animator animator;

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
    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        boxcollider = gameObject.GetComponent<BoxCollider2D>();

    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            playerCollided++;
            attack = true;
            boxcollider.size = newColliderSize;
            boxcollider.offset = newColliderOffset;
            animator.SetBool("attack", true);
            SoundManager.Instance.PlayMusic(Sounds.ChomperAttack);

            if(playerCollided == 2)
            {

                PlayerController player = other.gameObject.GetComponent<PlayerController>();
                player.PlayerDied();
                Destroy(gameObject);
               
            }
            return;
            
        }

        if(other.gameObject.layer == groundLayer || other.gameObject.layer == movingPlatformLayer)
        {
            if(attack)
            {
                rigidbody.velocity = jump;
            }
            return;
        }  

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == deathLayer)
        {
            Destroy(gameObject);
        }
    }


}
