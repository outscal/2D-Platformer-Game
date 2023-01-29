using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jump;
    public Animator animator;
    private Rigidbody2D Rigid2D;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision " + collision.gameObject.name);
        Rigid2D = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        AnimationMade(speed, vertical);
        Movement(speed, vertical);
    }
    void Movement(float speed, float vertical)
    {
        Vector3 position = transform.position;
        position.x = position.x + speed * Time.deltaTime;
        transform.position = position;
        if (vertical > 0)
        {
            Rigid2D.AddForce(new Vector2(0f,jump), ForceMode2D.Force);
        }

    }
    void AnimationMade(float speed, float jumpinput)
    {
        bool Jump = false;
        //float jumpinput = Input.GetAxisRaw("Vertical");
        bool crouch = false;
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (jumpinput > 0)
        {
            Jump = true;
            crouch = false;
        }
        else if (jumpinput == 0)
        {
            Jump = false;
            crouch = false;
        }
        else if (jumpinput < 0)
        {
            Jump = false;
            crouch = true;
        }
        animator.SetBool("Jump", Jump);
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        animator.SetBool("Crouch", crouch);
    }
}
