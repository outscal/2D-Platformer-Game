using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

    
{
    public Animator In_Anim;
    public BoxCollider2D playerCol;
    
   
   
    // Start is called before the first frame update
    void Start()
    {
        playerCol =playerCol.GetComponent<BoxCollider2D>();
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
        float speed = Input.GetAxisRaw("Horizontal");
        In_Anim.SetFloat("speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed>0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        float up = Input.GetAxisRaw("Vertical");
        bool jump = false;
        if (up > 0)
        {
            jump = true;
        }
        In_Anim.SetBool("jump", jump);

        
        

        
        bool pressCtrl = Input.GetKeyDown(KeyCode.LeftControl);
        bool releaseCtrl = Input.GetKeyUp(KeyCode.LeftControl);
        Vector2 size = playerCol.size;
        Vector2 offse = playerCol.offset;
        if (pressCtrl) {
            
            In_Anim.SetBool("crouch", true);
            /*Debug.Log(oldsize);*/
            playerCol.size = new Vector2(size.x,0.6f*size.y) ;
            playerCol.offset = new Vector2(offse.x, 0.6f * offse.y);
        }
        else if(releaseCtrl)
        {
            In_Anim.SetBool("crouch", false);
            /*Debug.Log(oldsize);*/
            playerCol.size = new Vector2(size.x, 2.085643f);
            playerCol.offset = new Vector2(offse.x, 0.9831027f);
        }
        

    }
}
