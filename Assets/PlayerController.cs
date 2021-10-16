using UnityEngine;

public class PlayerController:MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    float direction;
    Vector2 boxSize;
    Vector2 boxOffset;
    public LayerMask ground;

    private void Start()
    {
         boxSize = GetComponent<BoxCollider2D>().size;
         boxOffset = GetComponent<BoxCollider2D>().offset;
    }

    private void Update()
    {
        Run();
        jump();
        crouch();

    }

    private void Run()
    {
        direction = Input.GetAxis("Horizontal");
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0 , 0);
        if(direction!=0)
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
            GetComponent<BoxCollider2D>().size = new Vector2(boxSize.x, boxSize.y / 2);
            GetComponent<BoxCollider2D>().offset = boxOffset - new Vector2(0, 0.5f);
        }
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            GetComponent<Animator>().SetBool("Crouch", false);
            GetComponent<BoxCollider2D>().size = boxSize;
            GetComponent<BoxCollider2D>().offset = boxOffset - new Vector2(0, 0);
        }
    }    

    bool isGround()
    {
        RaycastHit2D rayHit = Physics2D.BoxCast(GetComponent<BoxCollider2D>().bounds.center, GetComponent<BoxCollider2D>().bounds.size, 0, Vector2.down, 0.1f, ground);
        return rayHit.collider != null;
    }
}