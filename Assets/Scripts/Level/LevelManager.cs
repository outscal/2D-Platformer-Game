using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // singleton - to keep only one instance of it all over the game 
    private static LevelManager instance;

    /* to only read the value of instance */ 
    public static LevelManager Instance { get { return instance; } }

    public string[] Levels;

    private void Awake()
    {
        /* the very first time this game obj comes into existence, it's instance will be null so setting its value to the 
         * correct obj & that shouldn't be destroyed because this LevelManager is going to be consistent throughout the 
         entire game */
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        /* if somehow a copy of it is created then we're destroying it */
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // the very first time the game starts, the first level1 should be unlocked to play 
        if (GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }

    public void MarkLevelComplete()
    {
        // finding the index of the active level from the array of Levels
        int currentSceneIndex = Array.FindIndex(Levels, level => level == SceneManager.GetActiveScene().name);

        // set levelStatus to complete
        SetLevelStatus(Levels[currentSceneIndex], LevelStatus.Completed);

        // unlock the next level
        if (currentSceneIndex + 1 < Levels.Length)
        {
            SetLevelStatus(Levels[currentSceneIndex + 1], LevelStatus.Unlocked);
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
    }
}

