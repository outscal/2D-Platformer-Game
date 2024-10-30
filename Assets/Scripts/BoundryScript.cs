using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundryScript : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (other.CompareTag("Player"))
        {
                SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
