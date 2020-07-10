using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteDetector : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            Debug.Log("level complete");
        }
    }
}
