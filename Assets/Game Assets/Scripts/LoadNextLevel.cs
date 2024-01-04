using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{

    // The name of the next scene to load
    public string nextLevel;

    // The tag of the gameobject that triggers the level end
    public string endTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Load the next scene
            SceneManager.LoadScene(nextLevel);

        }
    }
}
