using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public scoreController sc;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anmi;
    [SerializeField] GameObject resetButton;
     public  Button homeButton;
    [SerializeField] GameObject gameOverImage;
    [SerializeField] Collider2D bodyCollider;
    [SerializeField] Collider2D footCollider;

    [SerializeField] GameObject healthBar;
    bool crouch = false;
    bool ground;
    int movement = 1;
    
    public int speed;
    
    public float jumpForce;
    int numberOFLevels;
    public void KillPlayer()
    {
        anmi.SetBool("die", true);
        movement = 0;
        jumpForce = 0;
        Invoke("ShowGAMEOVER", 2);  
    }
    void ShowGAMEOVER()
    {
        resetButton.SetActive(true);
        gameOverImage.SetActive(true);
    }

    public void reset()
    {
        speed = 5;
        jumpForce = 100;
        SceneManager.LoadScene(1);
       

    }
    public void looseHealth()
    {
        healthBarController hbc;
        hbc = healthBar.GetComponent<healthBarController>();
        hbc.ChangeHealth(5);
        anmi.SetBool("hurt", true);
        Invoke("HurtFalse", 0.5f);

        

    }

    private void Awake()
    {
        homeButton.onClick.AddListener(GoToLobby);
    }

    private void GoToLobby()
    {
        SceneManager.LoadScene(0);
    }


    // Start is called before the first frame update
    void Start()
    {
        numberOFLevels = levelManager.Instance.Levels.Length;
        //Scene currentLevel = SceneManager.GetActiveScene();
        //levelManager.Instance.setLevelStatus(currentLevel.name, LevelStatus.unlocked);

    }

    // Update is called once per frame
    void Update()
    {
        //anmi.SetBool("hurt", false);
        anmi.SetInteger("motion", 0);
        anmi.SetBool("jump",!ground);
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0 , 0) * speed * Time.deltaTime*movement;
      
        
        if (Input.GetAxis("Horizontal") < 0 )
        {
                sr.flipX = true;
            if(Input.GetKey(KeyCode.LeftShift))
            {
                speed = 7;
                anmi.SetInteger("motion", 2);
            }
            else
            {
                speed = 5;
                anmi.SetInteger("motion", 1);
            }
          
        }if (Input.GetAxis("Horizontal") > 0 )
        {
                sr.flipX = false;
            if(Input.GetKey(KeyCode.LeftShift))
            {
                speed = 7;
                anmi.SetInteger("motion", 2);
            }
            else
            {
                speed = 5;
                anmi.SetInteger("motion", 1);
            }
          
        }

        if (Input.GetAxis("Vertical") > 0 && ground)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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

            Scene currentLevel = SceneManager.GetActiveScene();
            levelManager.Instance.setLevelStatus(currentLevel.name, LevelStatus.completed);
            if(numberOFLevels>currentLevel.buildIndex)
            {
                SceneManager.LoadScene(currentLevel.buildIndex + 1);
                //Scene nextLevel = SceneManager.GetSceneAt(currentLevel.buildIndex + 1);
                //SceneManager.LoadScene(nextLevel.buildIndex);
                //levelManager.Instance.setLevelStatus(nextLevel.name, LevelStatus.unlocked);
            }
            else
            {
                Debug.Log("game Complete");
            }
          
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
        if (collision.gameObject.CompareTag("enemy"))
        {
            anmi.SetBool("hurt", false);
        }
    }
    void HurtFalse()
    {
        anmi.SetBool("hurt", false);
    }
}
