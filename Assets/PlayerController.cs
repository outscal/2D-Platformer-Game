using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

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
    float score;
    public float playerHealth = 100;
    public Image healthBar;

    
    


    private void Start()
    {
         box = GetComponent<BoxCollider2D>();
         boxSize = box.size;
         boxOffset = box.offset;
        
    }

    private void Update()
    {
        Run();
        jump();
        crouch();
        scoreUpdate();
        reloadLevelAfterDeath();
        healthBarUpdate();

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
            print("Hi");
            SceneManager.LoadScene(3);
        }

        if (other.gameObject.tag == "nextlevel")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            PlayerPrefs.SetInt("sceneNoo", SceneManager.GetActiveScene().buildIndex);

        if (other.gameObject.tag == "collectible")
        {
            score += 10;
            other.gameObject.GetComponent<Animator >().SetTrigger("collected");
            Destroy(other.gameObject,1);
        }
        
    }

    



    void scoreUpdate()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void reloadLevelAfterDeath()
    {
        if(playerHealth<=0)
        {
            SceneManager.LoadScene(3);
        }
    }

    void healthBarUpdate()
    {
        healthBar.fillAmount = playerHealth / 100;
    }
}