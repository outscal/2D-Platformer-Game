using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string[] Levels;
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
        if(GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }
    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        //set level status to complete
        SetLevelStatus(currentScene.name, LevelStatus.Completed);


        //Unlock next level and Load it
        int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
            SceneManager.LoadScene(Levels[nextSceneIndex]);
        }
        else
        {

        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
        return levelStatus;
        
    }
    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting Level: " + level + "Status: " + levelStatus);
    }
    public void LevelsReset()
    {
        for (int i = 0; i < Levels.Length; i++)
        {
            // Unlock the first level
            if (i == 0)
            {
                SetLevelStatus(Levels[i], LevelStatus.Unlocked);
            }
            else
            {
                // Lock all other levels
                SetLevelStatus(Levels[i], LevelStatus.Locked);
            }
        }
    }

}