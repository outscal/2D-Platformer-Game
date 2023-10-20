using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator doorAnimation;

    private void Start()
    {
        doorAnimation = GetComponent<Animator>();
        doorAnimation.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log(other);
        doorAnimation.enabled = true;
    }
}
