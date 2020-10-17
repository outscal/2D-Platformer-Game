using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbRightEnemyController : MonoBehaviour
{
    //PlayerController playerController;

    [Range(1.0f, 10.0f)]
    public float speed = 5;


   
    Rigidbody2D _rigidbody;
    Animator _animator;


    //private bool movingRight;
    
    private void Awake()
    {

       

        _rigidbody = GetComponent<Rigidbody2D>();

        _animator = GetComponent<Animator>();

        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody2D component missing From the gameobject");
        }
        if (_animator == null)
        {
            Debug.LogError("animator component missing From the gameobject");

            _animator = gameObject.AddComponent<Animator>();

        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision " + collision.gameObject.name);
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Die"))
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);
        _animator.SetBool("Moving", true);


          
        
        
    }

   

}
