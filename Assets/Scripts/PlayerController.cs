using UnityEngine;

public class PlayerController : MonoBehaviour

    
{
    public Animator In_Anim;
    public BoxCollider2D playerCollider;
    
   
   
    // Start is called before the first frame update
    void Start()
    {
        playerCollider =gameObject.GetComponent<BoxCollider2D>();
        Debug.Log("Starting Player");
        
    }
    private void Awake()
    {
       
        Debug.Log("Player Awake");
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player hits " + collision.gameObject.name);
    }

    

    // Update is called once per frame
    public void Update()
    {
        //understand dif between GetAxis and GetAxisRaw..
        bool pressCtrl = Input.GetKeyDown(KeyCode.LeftControl);
        bool releaseCtrl = Input.GetKeyUp(KeyCode.LeftControl);
        Vector2 position = transform.localPosition;
        float displace = 5.0f;
        float speed = Input.GetAxisRaw("Horizontal");
        In_Anim.SetFloat("speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0 )
        {
            
            scale.x = -1f * Mathf.Abs(scale.x);
            position.x += speed * displace * Time.deltaTime;
            transform.position = position;
        }
        else if (speed>0 && pressCtrl == false)
        {
            scale.x = Mathf.Abs(scale.x);
            position.x += speed * displace * Time.deltaTime;
            transform.position = position;
        }
        transform.localScale = scale;

        float up = Input.GetAxisRaw("Vertical");
        bool jump = false;
        if (up > 0)
        {
            jump = true;
        }
        In_Anim.SetBool("jump", jump);

        
        

        
        
        Vector2 size = playerCollider.size;
        Vector2 offset = playerCollider.offset;
        
        if (pressCtrl) {
            
            In_Anim.SetBool("crouch", true);
            /*Debug.Log(oldsize);*/
            playerCollider.size = new Vector2(size.x,0.6f*size.y) ;
            playerCollider.offset = new Vector2(offset.x, 0.6f * offset.y);
        }
        else if(releaseCtrl)
        {
            In_Anim.SetBool("crouch", false);
            /*Debug.Log(oldsize);*/
            playerCollider.size = new Vector2(size.x, 2.1f);
            playerCollider.offset = new Vector2(offset.x, 0.98f);
        }
        

    }
}
