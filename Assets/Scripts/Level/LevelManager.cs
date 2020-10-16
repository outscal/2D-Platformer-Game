using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    private static LevelManager _instance;
    public static LevelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log(" Level Manager Instance is NULL");
            }
            return _instance;
        }
    }
    public void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    string[] Levels = {"Lobby", "Level1", "Level2", "Level3", "Level4" }; 


    public string Level1 = "Level1"; 

    // Start is called before the first frame update
    void Start()
    {
       
        if (GetLevelStatus(Level1) == LevelStatus.Locked)
        {
            SetLevelStatus(Level1, LevelStatus.UnLocked); 
        }    
  

        Debug.Log("level stats "+ GetLevelStatus("Level3")); 
    }


    void UnlockReset()
    {
        for (int i = 1; i < Levels.Length; i++)
        {
            SetLevelStatus(Levels[i], LevelStatus.Locked);
        }
        Debug.Log("Levels reset to locked");

    }
    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
       
        SetLevelStatus(currentScene.name, LevelStatus.Completed);
        int nextSceneIndex = currentScene.buildIndex + 1;

        if (nextSceneIndex < Levels.Length)
        SetLevelStatus(Levels[nextSceneIndex], LevelStatus.UnLocked);
        Debug.Log("level complete"); 
        SceneManager.LoadScene(0); 
    }


    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0); 
        return levelStatus; 
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Level Status :" + level); 

    }


}
