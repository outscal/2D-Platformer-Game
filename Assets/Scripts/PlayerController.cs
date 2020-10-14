using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;




public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public bool crouch = false;
    public float speed;

    private void Awake()
    {
        Debug.Log("Player Controllor Awake");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collison : " + collision.gameObject.name);
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        playerMoveAnime(horizontal);
        movePlayerHorizontal(horizontal);

    }

    private void movePlayerHorizontal(float horizontal)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
    }
    private void playerMoveAnime(float horizontal)
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1f, 1.883191f);
            animator.SetBool("crouch", true);

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1f, 1.983191f);
            animator.SetBool("crouch", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            animator.SetBool("Jump", true);
        }
        else if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("Jump", false);
        }
    }
}