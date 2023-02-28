using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        // Check if Player is Colliding
        if (other.gameObject.GetComponent<PlayerController>() != null) {
            Debug.Log("Level is Complete.");
        }
    }
}
