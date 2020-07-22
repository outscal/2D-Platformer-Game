using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private int chomperLayer = 10;
    private int GunnerLayer = 11;

    public bool FootStepSoundPlaying = false;

    public GameObject player;

    private int groundLayer = 9;
    public Animator animator;
    private void Update()
    {
        animator.SetBool("Walk", true);

        if (gameObject.layer == GunnerLayer)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < 15)
            {
                SoundManager.Instance.Play(Sounds.ChomperMovement);
            }


        }

        else if(gameObject.layer == chomperLayer)
        {
            
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < 15)
            {
                SoundManager.Instance.Play(Sounds.ChomperMovement);
            }

        }
    }

   


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            //speed = 0;
            player.PlayerDied();
        }

        if(other.gameObject.layer != groundLayer) 
        {
            Vector2 rotation = transform.eulerAngles;
            rotation.y += 180;
            transform.eulerAngles = rotation;
        }
       
    }
}
