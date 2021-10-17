using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anmi;
    bool crouch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        anmi.SetFloat("run",0);
        transform.position += new Vector3(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical") *3, 0) *5*Time.deltaTime;
        if(Input.GetAxis("Horizontal")>0)
        {
            sr.flipX = false;
            anmi.SetFloat("run" ,0.6f);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
            anmi.SetFloat("run", 0.6f);
        }
        if(Input.GetAxis("Vertical")>0)
        {
            
            anmi.SetBool("jump", true);

        }
        else
        {
            anmi.SetBool("jump", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouch = !crouch;
            anmi.SetBool("crouch", crouch);
           

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("door"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
