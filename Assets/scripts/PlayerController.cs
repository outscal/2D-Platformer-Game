using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    public void Awake()
    {
        Debug.Log("player controller awake");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision: " + collision.gameObject.name);
    }
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if (speed<0)
        {
            
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(speed>0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
        

}
