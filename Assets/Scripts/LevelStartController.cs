using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log(" New Level Start ");
            Debug.Log(" Proceed to exit point to finish current level and load New Level ");
        }
    }
}
