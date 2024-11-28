using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensure LevelManager persists across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance of LevelManager
        }
    }

    private void Start()
    {
        // Log LevelManager initialization
        Debug.Log("LevelManager initialized!");
        Time.timeScale = 1f;
        // Initialize Level 1 as Unlocked
        if (GetLevelStatus("Level1") == LevelStatus.Locked)
        {
            SetLevelStatus("Level1", LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string levelName)
    {
        return (LevelStatus)PlayerPrefs.GetInt(levelName, (int)LevelStatus.Locked); // Default to Locked
    }

    public void SetLevelStatus(string levelName, LevelStatus status)
    {
        PlayerPrefs.SetInt(levelName, (int)status);
        PlayerPrefs.Save();  // Ensure the status is saved
    }

    public void ResetPlayerData()
    {
        // Delete keys for all levels to reset their status
        for (int i = 1; i <= 5; i++) // Assuming you have 5 levels
        {
            PlayerPrefs.DeleteKey("Level" + i); // Delete the key for each level
        }

        PlayerPrefs.Save(); // Ensure changes are saved
    }
    public void SetCurrentLevelComplete()
    {
        // Mark the current level as Completed
        //string currentLevelName = SceneManager.GetActiveScene().name;
        //SetLevelStatus(currentLevelName, LevelStatus.Completed);

        //// Unlock the next level (if any)
        //int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        //string nextLevelName = "Level" + nextLevelIndex;

        //if (nextLevelIndex <= 5) // Assuming you have 5 levels
        //{
        //    SetLevelStatus(nextLevelName, LevelStatus.Unlocked);
        //}

        string currentLevelName = SceneManager.GetActiveScene().name;
        SetLevelStatus(currentLevelName, LevelStatus.Completed);

        // Unlock the next level (if any)
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        string nextLevelName = "Level" + nextLevelIndex;

        if (nextLevelIndex <= 6) // Assuming Level 1 to Level 5 are in scenes 1-5
        {
            SetLevelStatus(nextLevelName, LevelStatus.Unlocked);
        }

        // Check if the current level is the last level (Scene 5)
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Debug.Log("Final level completed! Resetting player data...");

            // Reset all levels to locked except Level 1
            ResetPlayerData();
            SetLevelStatus("Level1", LevelStatus.Unlocked);

            // Optionally, return to the lobby
            SceneManager.LoadScene(0); // Load the Lobby (Scene 0 in build settings)
        }
    }
}
