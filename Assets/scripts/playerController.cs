using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anmi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anmi.SetFloat("run",0);
        transform.position += new Vector3(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical"),0) *5*Time.deltaTime;
        if(Input.GetAxis("Horizontal")>0)
        {
            sr.flipX = false;
            anmi.SetFloat("run" ,0.6f);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
            anmi.SetFloat("run", 0.6f);
        }
        if()


    }
}
