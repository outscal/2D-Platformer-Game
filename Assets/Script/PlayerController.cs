using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private void Awake()
    {
        Debug.Log("Player controller awake");
    }
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
    }
}
 