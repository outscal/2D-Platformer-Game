using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class PlayerController:MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    float direction;
    Vector2 boxSize;
    Vector2 boxOffset;
    public LayerMask ground;
    BoxCollider2D box;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    float score;
    public float playerHealth = 100;
    public Image healthBar;
    public int levelclear;
    public GameObject pausePanel;
    public GameObject levelClearedPanel;
    public GameObject diedPanel;
    public AudioClip newLevelSound;
    public AudioClip playerDiedSound;
    AudioSource audioController;



    private void Start()
    {
         LevelManage.Instance.levelStatus = SceneManager.GetActiveScene().buildIndex;
         box = GetComponent<BoxCollider2D>();
         audioController = GetComponent<AudioSource>();
         boxSize = box.size;
         boxOffset = box.offset;
         pausePanel.SetActive(false);
        diedPanel.SetActive(false);
        levelClearedPanel.SetActive(false);
        
       
        
    }

    private void Update()
    {
        Run();
        jump();
        crouch();
        scoreUpdate();
        levelUpdate();
        reloadLevelAfterDeath();
        healthBarUpdate();
        levelclear = LevelManage.Instance.levelStatus ;

    }
    

    private void Run()
    {
        direction = Input.GetAxis("Horizontal");
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);
        if (direction!=0)
        {
            GetComponent<Animator>().SetFloat("Speed", 1);
            if (direction < 0) GetComponent<SpriteRenderer>().flipX = true;
            if (direction > 0) GetComponent<SpriteRenderer>().flipX = false;
        }
        else
            GetComponent<Animator>().SetFloat("Speed", 0);
    }
    
    private void jump()
    {
        if(isGround())
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10*jumpSpeed));
                GetComponent<Animator>().SetBool("jump", true);
            }
            else 
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
                GetComponent<Animator>().SetBool("jump", false);

            }
        }

    }

    private void crouch()
    {
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            GetComponent<Animator>().SetBool("Crouch", true);
            box.size = new Vector2(boxSize.x, boxSize.y / 2);
            box.offset = boxOffset - new Vector2(0, 0.5f);
        }
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            GetComponent<Animator>().SetBool("Crouch", false);
            box.size = boxSize;
            box.offset = boxOffset - new Vector2(0, 0);
        }
    }    

    bool isGround()
    {
        RaycastHit2D rayHit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, Vector2.down, 0.1f, ground);
        return rayHit.collider != null;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            AudioSource.PlayClipAtPoint(playerDiedSound, Camera.main.transform.position );
            GetComponent<Animator>().SetTrigger("died");
            diedPanel.SetActive(true);
        }

        if (other.gameObject.tag == "nextlevel")
        {
            AudioSource.PlayClipAtPoint(newLevelSound, Camera.main.transform.position);
            activateLevelClearedPanel();
        }
        

        if (other.gameObject.tag == "collectible")
        {
            score += 10;
            other.gameObject.GetComponent<Animator>().SetTrigger("collected");
            Destroy(other.gameObject, 1);
        }

    }

    public  void LoadNextLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("sceneNoo", SceneManager.GetActiveScene().buildIndex);
        
       
    }

    void activateLevelClearedPanel()
    {
        audioController.PlayOneShot(newLevelSound);
        levelClearedPanel.SetActive (true);
    }

    void scoreUpdate()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void levelUpdate()
    {
        levelText.text = "Level: " + SceneManager.GetActiveScene().buildIndex.ToString();
    }
    public void reloadLevelAfterDeath()
    {
        if(playerHealth<=0)
        {
            AudioSource.PlayClipAtPoint(playerDiedSound, Camera.main.transform.position);
            GetComponent<Animator>().SetTrigger("died");
            
            diedPanel.SetActive(true);
        }
    }

    void healthBarUpdate()
    {
        healthBar.fillAmount = playerHealth / 100;
    }

    
}