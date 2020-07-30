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

    void Start()
    {
        animator.SetBool("attack", true);
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            SoundManager.Instance.Play(Sounds.ChomperAttack);
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (!other.gameObject.GetComponent<Animator>().GetBool("Died"))
            {
                player.PlayerDied();
            }
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

        if (other.gameObject.layer == deathLayer)
        {
            Destroy(gameObject);
        }


    }

}
