using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Player COntroller is awake");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision: " + collision.gameObject.name);
    }

}
