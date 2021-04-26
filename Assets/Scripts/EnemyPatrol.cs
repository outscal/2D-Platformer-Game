using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb2d;
    public LayerMask groundLayers;

    public Transform groundCheck;
    bool isFacingLeft = true;

    RaycastHit2D hit;


    private void Update()
    {
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
    }

    private void FixedUpdate()
    {
        if(hit.collider != false)
        {
            Debug.Log("Hitting Ground");
            if (isFacingLeft)
            {
                rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            }
            else 
            { 
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            }
        }

        else
        {
            Debug.Log("Not Hitting Ground");
            isFacingLeft = !isFacingLeft;
            transform.localScale = new Vector3(-transform.localScale.x, 0.3f, 1f);

        }
    }
}
