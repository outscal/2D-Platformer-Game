using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyController : MonoBehaviour
{

    //new implementation
    private bool mustPatrol;
    private bool mustTurn;
    [SerializeField]
    private float walkSpeed;
    public Transform groundCheckPos;
    public LayerMask groundLayer;

    Rigidbody2D rb2d;
    Animator _animator;
    Player_Controller playerController;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerController = gameObject.GetComponent<Player_Controller>();
        mustPatrol = true;
    }
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }
    void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }
 

    private void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }
        rb2d.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb2d.velocity.y);
    }
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true; 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("Attack", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Player_Controller player_controller = collision.gameObject.GetComponent<Player_Controller>(); 
            player_controller.KillPlayer();
          
        }
    }
 
}
