using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        MoveCharachtar(horizontal);
        PlayMovementAnimation(horizontal);

        
    }

    private void MoveCharachtar(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void PlayMovementAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

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

        bool crouch = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("Crouch", crouch);

        float jump = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Jump", jump);


        //bool jump = Input.GetKey(KeyCode.Space);
        //animator.SetBool("JumpTriggered", jump);
    }

}
