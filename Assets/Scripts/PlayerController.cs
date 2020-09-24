using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision " + collision.gameObject.name);
    }
    void Start()
    {
        
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

        if(Input.GetKey(KeyCode.C))
        {
            animator.SetBool("isCrouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool("isCrouch", false);
        }
    }
}
