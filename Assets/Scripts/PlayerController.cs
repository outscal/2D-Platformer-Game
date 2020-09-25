using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public BoxCollider2D player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Running and turning
        float speed = Input.GetAxis("Horizontal");
        //Debug.Log("Horizaontal Speed = " speed);
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(speed>0) {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;


        //Crouching
        player = player.GetComponent<BoxCollider2D>();
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            animator.SetBool("IsCrouch", true);
            player.size = new Vector2(player.size.x, (player.size.y) * 0.6f);
            player.offset = new Vector2(player.offset.x, (player.offset.y) *0.6f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            animator.SetBool("IsCrouch", false);
            player.size = new Vector2(player.size.x, (player.size.y) / 0.6f);
            player.offset = new Vector2(player.offset.x, (player.offset.y) / 0.6f);
        }

        //Jumping
        float jump = Input.GetAxis("Vertical");
        animator.SetFloat("Jump", jump);
        /*if (jump > 0.3)
        {
            player.size = new Vector2(player.size.x, (player.size.y) * 0.6f);
            player.offset = new Vector2(player.offset.x, (player.offset.y) / 0.6f);
        }

        else if(jump < 0.3 && jump >0){
            player.size = new Vector2(player.size.x, (player.size.y) / 0.6f);
            player.offset = new Vector2(player.offset.x, (player.offset.y) * 0.6f);
        }*/
    }
   
}   
