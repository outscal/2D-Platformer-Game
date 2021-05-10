using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollider : MonoBehaviour
{
    bool groundChecker;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("jump controller is working if true :"+collision.gameObject.CompareTag("ground"));
        groundChecker = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        groundChecker = false;
    }

    public bool GrounChecker()
    {
        return groundChecker;
    }
}
