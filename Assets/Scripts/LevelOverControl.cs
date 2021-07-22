using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverControl : MonoBehaviour

{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Level Complete");
        }
    }
}

