using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnCollisionEnter20(Collision2D collision)
    {
        Debug.Log("collision" + collision.gameObject.name);
    }
    
}
