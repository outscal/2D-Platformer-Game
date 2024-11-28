using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLockManager : MonoBehaviour
{
    public static LevelLockManager Instance { get; private set; }

    [System.Serializable]
    public class LevelButton
    {
        public Button button;            // Reference to the level button
        public GameObject lockImage;     // Lock image child of the button
    }

    public LevelButton[] levelButtons;   // Array of level buttons with lock images

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of LevelLockManager
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    private void Start()
    {
        UpdateLevelButtons();
    }

    public void UpdateLevelButtons()
    {
        // Unlock the first level by default
        if (levelButtons.Length > 0)
        {
            levelButtons[0].button.interactable = true;
            levelButtons[0].lockImage.SetActive(false); // Hide lock image for the first level
        }

        // Loop through each level and check if it's unlocked
        for (int i = 1; i < levelButtons.Length; i++)
        {
            // Check PlayerPrefs for each level's unlock status
            if (PlayerPrefs.GetInt("Level" + i.ToString()) == 1)
            {
                levelButtons[i].button.interactable = true;    // Unlock level
                levelButtons[i].lockImage.SetActive(false);    // Hide lock image
            }
            else
            {
                levelButtons[i].button.interactable = false;   // Keep level locked
                levelButtons[i].lockImage.SetActive(true);     // Show lock image
            }
        }
    }

    // Method to unlock the next level when a level is completed
    public void UnlockNextLevel(int currentLevelIndex)
    {
        int nextLevelIndex = currentLevelIndex;
        PlayerPrefs.SetInt("Level" + nextLevelIndex.ToString(), 1); // Mark the next level as unlocked
    }

    // Method to reset all level locks (if needed)
    public void ResetLevelLocks()
    {
        for (int i = 1; i < levelButtons.Length; i++)
        {
            PlayerPrefs.SetInt("Level" + i.ToString(), 0); // Reset each level lock
            levelButtons[i].button.interactable = false;   // Lock each level
            levelButtons[i].lockImage.SetActive(true);     // Show lock image
        }

        // Ensure the first level remains unlocked
        if (levelButtons.Length > 0)
        {
            levelButtons[0].button.interactable = true;
            levelButtons[0].lockImage.SetActive(false);
        }
    }
}
