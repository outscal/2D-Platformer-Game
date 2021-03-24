using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Cached references
    BoxCollider2D boxCollider;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Collision :" + collision.gameObject.name);   
    }
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float vSpeed = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (vSpeed > 0)
        {
            animator.SetBool("Jump", true);
        }
        else if (vSpeed <= 0)
        {
            animator.SetBool("Jump", false);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", true);
            boxCollider.offset =  new Vector2(0.05f,0.77f);
            boxCollider.size =  new Vector2(0.95f, 1.6f);
        }

        else
        {
            animator.SetBool("isCrouch", false);
            boxCollider.offset = new Vector2(0.024f,1.01f);
            boxCollider.size = new Vector2(0.62f,2.07f);
        }
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
}
