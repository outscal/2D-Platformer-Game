using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float moveValue = 0;

    private SpriteRenderer playerSprite_R;
    private Animator playerAnimator;
    // Start is called before the first frame update
    private void Start()
    {
        playerSprite_R = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {

        //input approach 1 smooth movement 
        /*moveValue = Input.GetAxis("Horizontal");*/

        //input approach 2 raw Movement and time.deltatime 
        moveValue = Input.GetAxisRaw("Horizontal");     
        if (moveValue > 0)
        {

            //sprite flip approach1 scale 
            transform.localScale = Vector3.one;
            //sprite flip approach2 flip value
    
        }

        if (moveValue < 0)
        {
            //sprite flip approach1 scale 
            transform.localScale = new Vector3(-1,1,1);
            //sprite flip approach2 flip value
            //playerSprite_R.flipX = true;
        }

        playerAnimator.SetFloat("Speed",Mathf.Abs(moveValue));

    }
}
