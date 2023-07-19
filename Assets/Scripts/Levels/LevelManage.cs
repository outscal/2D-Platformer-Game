using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class LevelManage : MonoBehaviour
{
    private static LevelManage instance;
    public string[] Levels;
    public static LevelManage Instance { get { return instance; } }
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
        if(GetLevelStatus(Levels[0]) ==LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }
    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        //set level status to complete
        LevelManage.Instance.SetLevelStatus(currentScene.name, LevelStatus.Completed);

        //unlockt the next level

        //int nextSceneIndex = currentScene.buildIndex + 1;
        //Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        //LevelManage.Instance.SetLevelStatus(nextScene.name, LevelStatus.Unlocked);
       int currentSceneIndex =  Array.FindIndex(Levels, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex > Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
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
    }
}

