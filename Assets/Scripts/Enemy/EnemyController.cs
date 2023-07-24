using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public float speed;
    private Animator anim;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetection;
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);   
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D grndfInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (grndfInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
            // Destroy(gameObject);
        }
    }
}
