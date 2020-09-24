using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    BoxCollider2D Collider;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision " + collision.gameObject.name);
    }
    void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if(Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", true);
            Collider.offset = new Vector2(-0.013f, 0.64f);
            Collider.size = new Vector2(0.95f, 1.33f);
            
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", false);
            Collider.offset = new Vector2(0.013f, 0.983f);
            Collider.size = new Vector3(0.6f, 2.1f);
        }
        
    }
}


