using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;




public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public bool crouch = false;
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
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0 )
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