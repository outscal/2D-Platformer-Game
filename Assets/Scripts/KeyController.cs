using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    Animator animater;
    PlayerController pc;
    void Start()
    {
        animater= gameObject.GetComponent<Animator>();
        animater.SetBool("Taken",false);
    }
    void Update()
    {
        if(animater.GetBool("Disappeared"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        pc= collision.gameObject.GetComponent<PlayerController>();
        if(pc!=null&&animater.GetBool("Taken")==false)
        {
            pc.GetPoints();
            animater.SetBool("Taken",true);
        }
    }
}
