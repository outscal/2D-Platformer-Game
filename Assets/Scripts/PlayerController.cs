using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator Animator;
    bool isCrouched;


    void resizeBoxColliderSize()
    {
        Vector2 Box = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        //gameObject.GetComponent<BoxCollider2D>().size = Box;
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2((Box.x / 1), (Box.y / 5));

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        

        //isCrouched = Input.GetKeyDown(KeyCode.LeftControl);

        isCrouched = Input.GetKey(KeyCode.LeftControl);
       // Debug.Log(speed);
        Animator.SetFloat("Speed", Mathf.Abs(speed));

        Animator.SetBool("Crouched", isCrouched);
        if (isCrouched == true)
        {
            resizeBoxColliderSize();
        }

        else if (isCrouched == false)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.56f, 2.03f); 
        }
       
        
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            
            scale.x = -1f * Mathf.Abs(scale.x);
        }

        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;

        if (vert > 0)
        {
            Animator.SetBool("Jump", true);
        }

        else if (vert < 0)
        {
            Animator.SetBool("Jump", false);
        }

      
    }
}
