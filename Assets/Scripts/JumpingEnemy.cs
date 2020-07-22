using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{
    public Animator animator;
    public Vector2 jump;
    private int groundLayer = 9;
    private Rigidbody2D rigidbody;

    private int movingPlatformLayer = 20;
    private int deathLayer = 13;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("attack", true);
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            
            SoundManager.Instance.PlayMusic(Sounds.ChomperAttack);
                PlayerController player = other.gameObject.GetComponent<PlayerController>();
                player.PlayerDied();
                Destroy(gameObject);

         }

        

        if (other.gameObject.layer == groundLayer || other.gameObject.layer == movingPlatformLayer)
        {
            
                rigidbody.velocity = jump;
            
            
        }

        if(other.gameObject.GetComponent<JumpingEnemy>()!=null)
        {
            rigidbody.velocity = jump;
        }
       

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == deathLayer)
        {
            Destroy(gameObject);
        }
    }


}
