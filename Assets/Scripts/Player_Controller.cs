using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public Animator animator;

    private void Update()
    {
        float Speed =  Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Speed);
    }

}
