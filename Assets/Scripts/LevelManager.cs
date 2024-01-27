using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

   // private Scene[] Levels;
    public static LevelManager Instance { get{ return instance; } }

    private void Awake()
    {
        if (instance ==null)
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
        setLevelStatus("Level1",LevelStatus.Unlocked);
    }

    public void OnLevelCompletion(string nextLevelName)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        setLevelStatus(currentScene.name, LevelStatus.Completed);
        setLevelStatus(nextLevelName, LevelStatus.Unlocked);

    }
  


    public LevelStatus getLevelStatus(string level) 
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }
    public void setLevelStatus(string level, LevelStatus levelStatus) 
    {
        if (level == "LevelFinish")
        {
            Debug.Log("Game ended.");
        }
        else
        {
            PlayerPrefs.SetInt(level, (int)levelStatus);
            PlayerPrefs.Save();
            Debug.Log($"level status updated {level}, {levelStatus}");
        }
        
    }
}
