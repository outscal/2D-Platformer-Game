using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float playerSpeed = Input.GetAxisRaw("Horizontal");
        Debug.Log("Player Speed is:"+playerSpeed);
        animator.SetFloat("Speed", Mathf.Abs(playerSpeed));
        Vector3 scale = transform.localScale;
        if (playerSpeed<0)
        {
            scale.x = -1f* Mathf.Abs(scale.x);

        }
        else if (playerSpeed>0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
}
