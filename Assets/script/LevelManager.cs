using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance {get{return instance;}}

    public string Level1;

    public string[] Levels;

    

    private void Awake()
    {
        if (instance == null)
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
        if (GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);   
        }
    }

    public void MarkCurrentLevelComplete()          // set level status to complete and unlock next level
    {
        Scene currentscene = SceneManager.GetActiveScene();
        SetLevelStatus(currentscene.name, LevelStatus.Completed);

      
        int currentsceneIndex = Array.FindIndex(Levels, level => level == currentscene.name);
        int nextsceneIndex = currentsceneIndex + 1;
        
        if(nextsceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextsceneIndex], LevelStatus.Unlocked);
        }
    }
    
    public LevelStatus GetLevelStatus(string level)
    {
       LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
        return levelStatus;

    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
     {
        PlayerPrefs.SetInt(level, (int) levelStatus);
        Debug.Log("Setting level:" + level + "status:" + levelStatus);
     }


}

