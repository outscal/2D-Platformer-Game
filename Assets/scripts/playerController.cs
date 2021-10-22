using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public scoreController sc;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anmi;
    [SerializeField] GameObject resetButton;
    [SerializeField] Collider2D bodyCollider;
    [SerializeField] Collider2D footCollider;
    [SerializeField] GameObject[] heelthUI ;
    bool crouch = false;
    bool ground;
    public int speed;
    int numberOFLives = 3;
   
    public float jumpForce;

    public void KillPlayer()
    {
        anmi.SetBool("die", true);
        speed = 0;
        jumpForce = 0;
       resetButton.SetActive(true);


    }

    public void reset()
    {
        speed = 5;
        jumpForce = 100;
        SceneManager.LoadScene(1);
       

    }


    public void LoosePlayerLIfe()
    {
        
        healthController hc;
        numberOFLives -= 1;
        if(numberOFLives>=0)
        {
            hc = heelthUI[numberOFLives].GetComponent<healthController>();
            hc.looseHeart();

        }
        
            
        
        if (numberOFLives <= 0 )
        {
           KillPlayer();
        }
        

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        anmi.SetFloat("run", 0);
        anmi.SetBool("jump",!ground);
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0 , 0) * speed * Time.deltaTime;
        if (Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = false;
            anmi.SetFloat("run", 0.6f);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
            anmi.SetFloat("run", 0.6f);
        }
        if (Input.GetAxis("Vertical") > 0 && ground)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);

           

        }

       

      
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouch = !crouch;
            anmi.SetBool("crouch", crouch);


        }


    }
    public void  PickUpKey()
    {
        sc.IncrementScore(10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("door"))
        {
            SceneManager.LoadScene(1);
        }
        if (collision.gameObject.CompareTag("ground"))
        {
            ground = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            ground = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            ground = false;
        }
    }
}
