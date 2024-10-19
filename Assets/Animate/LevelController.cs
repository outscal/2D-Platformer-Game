using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null) {
            Debug.Log("Level finished");
            UnlockNewLevel();
            SceneController.instance.nextLevel();
        }
    }


    void UnlockNewLevel()
    {
        // Get the current level index and the levelAt value
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int levelAt = PlayerPrefs.GetInt("levelAt", 1); 

        // Check if the current level index is the last unlocked level
        if (currentLevelIndex == levelAt)
        {
            PlayerPrefs.SetInt("levelAt", levelAt + 1); // Increment levelAt to unlock the next level
            PlayerPrefs.Save(); // Save the changes
            Debug.Log("Unlocked level: " + (levelAt + 1)); // Log the new unlocked level
        }
    }

}



