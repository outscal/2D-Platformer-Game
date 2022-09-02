using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

    
{
    public Animator In_Anim;
    // Start is called before the first frame update
    void Start()
    {
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
    private void Update()
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
    }
}
