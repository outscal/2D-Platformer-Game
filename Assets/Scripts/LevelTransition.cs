using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentSceneIndex);
        if (other.CompareTag("Player"))
        {
            if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
            else
            {
                Debug.Log("No more scenes to load! You are at the last scene.");
            }
        }
    }
}
