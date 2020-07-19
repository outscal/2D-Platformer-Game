using System;
using System.Collections;
using System.Collections.Generic;
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
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level,0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting level: " + level + "status: " + levelStatus);
    }

    public void MarkCurrentLevelComplete()
    {
        SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);
        int currentIndex = SceneManager.GetActiveScene().buildIndex - 1;
        int nextIndex = currentIndex + 1;

        if(nextIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextIndex], LevelStatus.Unlocked);
        }

    }
}
