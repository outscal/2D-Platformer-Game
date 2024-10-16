using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object entering the trigger is the player
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            // Reload the current scene when the player falls into the death zone
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Respawned player");
        }
    }
}
