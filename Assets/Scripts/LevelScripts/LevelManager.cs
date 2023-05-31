using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance; // this is the private instance of the LevelManager class
    public static LevelManager Instance { get { return instance; } }  // This is the Public Instance of the LevelManager class

    [Tooltip("Enter level name (Level names are case sensitive!)")]
    [SerializeField] private string[] Levels;
    private int nextSceneIndex;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Make Level 1 Active at start of the Game
        if (GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }

    public string[] GetLevelName()
    {
        // Getter function for the Levels[] array
        return Levels;
    }

    public int GetNextLevelIndex()
    {
        // Getter function for the nextLevelIndex variable as it is not a good practice to define the public variable
        return nextSceneIndex;
    }

    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Set current level as completed
        SetLevelStatus(currentScene.name, LevelStatus.Completed);

        // Mark next level as unlocked
        int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);
        // For Level1 scene, even though in the Build settings its index is 1, but as per the array it is the first element so currentSceneIndex would be 0
        // So nextSceneIndex would become = 1
        // Levels[0] = Level1, Levels[1] = Level2, Levels[2] = Level3;
        nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
            Debug.Log(Levels[nextSceneIndex] + " Unlocked");
        }
    }

    // There should be 2 methods to set and get the level status of each level in the

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);  // Type-casting LevelStatus enum to the Integer
    }

    public LevelStatus GetLevelStatus(string level)
    {
        // by default level is gonna be locked so set the default int value to 0 => which corresponds to the Locked state
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0); // Type-casting the Interger into LevelStatus enum
        return levelStatus;
    }
}
