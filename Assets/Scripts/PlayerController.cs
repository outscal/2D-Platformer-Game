using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private BoxCollider2D m_playerCol;
    public float speed;
    public float jump;
    private Rigidbody2D m_rb2d;
    private bool m_onGround;
    public ScoreController scoreController;
    private GameObject[] players;
    public GameOverController gameOverController;
    
    

    private void Awake()
    {
        //Debug.Log("Player Controller awake");
        m_rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    

    public void KillPlayer()
    {
        //Debug.Log("Player killed by Enemy");
        gameOverController.PlayerDied();
        this.enabled = false;
    }

    public void PickUpKey()
    {
        //Debug.Log("Player picked up a KEY");
        scoreController.IncreaseScore(10);
        SoundManager.Instance.Play(Sounds.KeyPick);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision : " + collision.gameObject.name);
        m_onGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        m_onGround = false;
    }

    void Start()
    {
        //Debug.Log("Start Function ");
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector2 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        //Debug.Log("vertical value " + vertical); 

        if (vertical > 0 && m_onGround == true) 
        {
            m_rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
            m_onGround = false;
        }
    }
    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector2 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;


        
        if (vertical > 0)
        {
        animator.SetBool("JUMP", true);
        }
        else
        {
        animator.SetBool("JUMP", false);
        }


        bool isCrouching = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("isCrouch", isCrouching);
        m_playerCol = animator.GetComponent<BoxCollider2D>();
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
            m_playerCol.size = new Vector2(m_playerCol.size.x, 1.33f);
            m_playerCol.offset = new Vector2(m_playerCol.offset.x, 0.59f);
        }
        else
        {
            isCrouching = false;
            m_playerCol.size = new Vector2(m_playerCol.size.x, 2.118038f);
            m_playerCol.offset = new Vector2(m_playerCol.offset.x, 0.9803708f);
        }
    }

   private void OnLevelWasLoaded(int level)
   {
       FindStartPos();
       players = GameObject.FindGameObjectsWithTag("Player");
       if(players.Length > 1) 
       {
           Destroy(players[0]);
       }
   }

    public void FindStartPos()
    {
       transform.position = GameObject.FindWithTag("StartPos").transform.position;
    }    

    private void FootStep()
    {
        SoundManager.Instance.Play(Sounds.FootStep);
    }
}
