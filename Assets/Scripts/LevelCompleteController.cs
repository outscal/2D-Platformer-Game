using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level is Completed");
        }
    }
}
