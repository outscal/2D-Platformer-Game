using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
   
    public TextMeshProUGUI ScoreText;
    //public TextMeshProUGUI HealthText;
    private int score=0;
    public Animator animator;
    BoxCollider2D Collider;

    [Range(0.0f,10.0f)]
    public float speed=3.0f;
    public float Jump = 600f;
    //public int Health = 3;

   
    
    public LayerMask whatIsGround;
    public Transform GroundCheck;

    [HideInInspector]
    public bool PlayerCanMove = true;

    //private variables below

    Transform _transform;
    Rigidbody2D _rigidbody;
    Animator _animator;
    AudioSource _audioSource;
    float _vx;
    float _vy;

    //Tracking
    bool _facingRignt = true;
    bool _isGrounded = false;
    bool _isRunning = false;

    int _PlayerLayer;
    int _PlatformLayer;

    public AudioClip jumpSfx;
    public AudioClip MoveSfx;
    public AudioClip keypickupSfx;
    public AudioClip death;


    public void PickUpKey()
    {
        score=score+10;
        ScoreText.text = "Score : "+score.ToString("");
        _audioSource.PlayOneShot(keypickupSfx);


        //Debug.Log("Key Collected");
    }
    public void KillPlayer()
    {
        
        if (Health.health > 0)
        {
            Health.health--;
        }else if (Health.health <1)
        {
            PlayerCanMove = false;
            _audioSource.PlayOneShot(death);
            _animator.SetTrigger("Death");
            StartCoroutine("loadDelay");

        }

        //HealthText.text = "Health : " + Health.health.ToString("");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Die"))
        {
           
            Health.health = 0;

            _audioSource.PlayOneShot(death);

            _animator.SetTrigger("Death");
            StartCoroutine("loadDelay");
            PlayerCanMove = false;
            //SceneManager.LoadScene("1");
        }
    }
    
    void Awake()
    {

        
        //_animator.SetBool("Grounded", true);
        Collider = GetComponent<BoxCollider2D>();
       
        _transform = GetComponent<Transform>();

        _rigidbody = GetComponent<Rigidbody2D>();

        _animator = GetComponent<Animator>();

        _audioSource = GetComponent<AudioSource>();

        if(_rigidbody == null)
        {
            Debug.LogError("Rigidbody2D component missing From the gameobject");
        }
        if (_animator == null)
        {
            Debug.LogError("animator component missing From the gameobject");

            _animator = gameObject.AddComponent<Animator>();

        }
        _PlayerLayer = this.gameObject.layer;
        _PlatformLayer = LayerMask.NameToLayer("Platform");
    }
    void Start()
    {

        
        //HealthText.text ="Health : " +Health.health.ToString("");
        
    }

    
    // Update is called once per frame
    void Update()
    {

        

        if (!PlayerCanMove || Time.timeScale == 0)
            return;


        _vx = Input.GetAxisRaw("Horizontal");

        //float vertical = Input.GetAxisRaw("Jump");

        if (_vx != 0)
        {
            _isRunning = true;
            if (_audioSource.isPlaying == false)
            {
                _audioSource.PlayOneShot(MoveSfx);

            }

        }
        else
        {
            _isRunning = false;
        }
        _animator.SetBool("Running", _isRunning);


        _vy = _rigidbody.velocity.y;

        _isGrounded = Physics2D.Linecast(_transform.position, GroundCheck.position, whatIsGround);

        _animator.SetBool("Grounded", _isGrounded);

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(new Vector2(0f, Jump));
            _vy = 0;
            _audioSource.PlayOneShot(jumpSfx);
            
        }

        if (Input.GetKeyUp(KeyCode.Space) && _vy > 0f)
        {
            _vy = 0;
        }

        _rigidbody.velocity = new Vector2(_vx * speed, _vy);

        Physics2D.IgnoreLayerCollision(_PlayerLayer,_PlatformLayer,(_vy>0.0f));

        

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouch", true);
            Collider.offset = new Vector2(-0.013f, 0.64f);
            Collider.size = new Vector2(0.95f, 1.33f);

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouch", false);
            Collider.offset = new Vector2(0.013f, 0.983f);
            Collider.size = new Vector3(1.6f, 2.1f);
        }       
        
    }


    private void LateUpdate()
    {
        Vector3 localScale = transform.localScale;
        if (_vx > 0)
        {
            _facingRignt = true;
        }
        else if (_vx < 0)
        {
            _facingRignt = false;
        }

        if((_facingRignt)&&(localScale.x<0)||(!_facingRignt) && (localScale.x > 0)){
            localScale.x *= -1;
        }


        transform.localScale = localScale;
    }


    IEnumerator loadDelay()
    {

        if (Health.health == 0)
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("GameOver");
        }
    }

}


