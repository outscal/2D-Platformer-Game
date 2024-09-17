using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] Animator key_animator;
    float fade_out_animation = 0.15f;
    float timer = 0;
    private void Awake()
    {
        key_animator = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Debug.Log(timer);
            PlayerController controller = collision.gameObject.GetComponent<PlayerController>();
            //key_animator.SetBool("Key_Picked", true);
            //timer = Time.time;
            controller.PickupKey();
            Destroy(gameObject);
     
        }
    }
}
