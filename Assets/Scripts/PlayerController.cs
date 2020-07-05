using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxcollider;

    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("Player controller awake");
    }
    private void Start()
    {
        boxcollider.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame   
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
       

        Vector3 scale = transform.localScale;

        if(speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
        if (Input.GetKey(KeyCode.LeftControl)== true)
        {
            animator.SetBool("isSit", true);
            boxcollider.size = new Vector2(boxcollider.size.x,1.22f);
            boxcollider.offset = new Vector2(boxcollider.offset.x, 0.59f);
            
        }
        else
        {
            animator.SetBool("isSit", false);
            boxcollider.offset = new Vector2(boxcollider.offset.x, 0.98f);
            boxcollider.size = new Vector2(boxcollider.size.x, 2.011f);
        }
        float vertical = Input.GetAxisRaw("Jump");
        
        if (vertical > 0) 
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
