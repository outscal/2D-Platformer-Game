using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellen_Movement : MonoBehaviour
{
    public Animator anime;
    private SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        anime.SetFloat("Speed", Mathf.Abs(horizontal));

        if(horizontal < 0)
        {
            mySpriteRenderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            mySpriteRenderer.flipX = false;
        }
    }
}
