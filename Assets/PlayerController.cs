using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private void Update()
    {
        float speed = Input.GetAxis("Horizontal");
        GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(speed));
        if (speed < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        GetComponent<SpriteRenderer>().flipY = false;
        
    }
}
