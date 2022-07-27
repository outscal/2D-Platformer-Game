using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public LevelSelectionTextController levelSelectionTextController;
    
    public string[] Levels;

    private void Awake()
    {
        CreateLevelManager();
    }
    private void Start()
    {
        UnlockInitialGameScenes();
    }
    private void CreateLevelManager()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void UnlockInitialGameScenes()
    {
        SetLevelStatus("Lobby", LevelStatus.Unlocked);
        if (GetLevelStatus(Levels[0]) == LevelStatus.Locked)
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
    }

    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        //set level status to complete
        LevelManager.Instance.SetLevelStatus(currentScene.name, LevelStatus.Completed);

        //set next level status to unlocked
        int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }
    }

    public void LoadAnyLevel(string LevelName)
    {
        LevelStatus levelStatus;
        if(LevelName == "Lobby")
        {
            LevelManager.Instance.SetLevelStatus(LevelName, LevelStatus.Unlocked);
            levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        }
        else
        {
            levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        }

        switch (levelStatus)
        {
            case LevelStatus.Locked:
            {
                levelSelectionTextController.DisplayLockedText();
                break;
            }
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                break;
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);   
        return levelStatus;
    }
    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("level name:" + level + "\nStatus: " + levelStatus);
    }

    public void PlayNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //call this when quiting game
    public void SetResumeGameLevel(string keyName)
    {
        PlayerPrefs.SetInt(keyName, SceneManager.GetActiveScene().buildIndex);
    }

    //call this for resume game button
    public void ResumeLastLevelPlayed(string lastLevelPlayedByBuildIndex)
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt(lastLevelPlayedByBuildIndex));
    }

    public void ResetGameValues()
    {
        PlayerPrefs.DeleteAll();
        LevelManager.Instance.SetLevelStatus("Level1", LevelStatus.Unlocked);
    }
}