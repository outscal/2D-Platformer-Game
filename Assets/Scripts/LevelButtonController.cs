using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{

    [SerializeField] private Button[] levelButtons; // Array of buttons for each level

    private void Start()
    {
        if (levelButtons == null || levelButtons.Length == 0)
        {
            Debug.LogError("Level buttons array is not set or empty.");
            return;
        }

        // Ensure LevelManager singleton is initialized
        if (LevelManager.Instance == null)
        {
            Debug.LogError("LevelManager instance is not found!");
            return;
        }

        // Loop through each button and set its interactable status based on level unlock status
        for (int i = 0; i < levelButtons.Length; i++)
        {
            string levelName = "Level" + (i + 1);  // Level names starting from Level1
            LevelStatus status = LevelManager.Instance.GetLevelStatus(levelName);

            // Log the level status for debugging purposes
            Debug.Log($"Level {i + 1} status: {status}");

            // Set interactable if unlocked or completed, else disable
            levelButtons[i].interactable = (status == LevelStatus.Unlocked || status == LevelStatus.Completed);

            // Capture the index for use in button click
            int levelIndex = i + 1;  // Build index starting from 1
            levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex)); // Assign listener for each button
        }
    }

    // Method to load a level by index, starting from build index 1
    public void LoadLevel(int levelIndex)
    {
        string levelName = "Level" + levelIndex;
        SoundController.Instance.Play(Sounds.ButtonClick);

        // Check if the level is unlocked or completed
        LevelStatus status = LevelManager.Instance.GetLevelStatus(levelName);
        if (status == LevelStatus.Unlocked || status == LevelStatus.Completed)
        {
            SceneManager.LoadScene(levelIndex); // Load the level by index (build index starts from 1)
        }
        else
        {
            Debug.Log("This level is locked.");
        }
    }



}
