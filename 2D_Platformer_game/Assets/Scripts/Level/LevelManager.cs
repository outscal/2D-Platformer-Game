using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
  private static LevelManager instance;
  public static LevelManager Instance { get {return instance;} }

  
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
       if(GetLevelStatus(Levels[0]) ==LevelStatus.Locked)
       {
           SetLevelStatus(Levels[0],LevelStatus.Unlocked);
       }
    }

    public void MarkCurrentLevelComplete()
    {
       Scene currentScene = SceneManager.GetActiveScene();
       SetLevelStatus(currentScene.name,LevelStatus.Completed);
        //    int nextSceneIndex = Currentscene.buildIndex + 1;
        //   Scene Nextscene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        //    SetLevelStatus(Nextscene.name,LevelStatus.Completed);
        int currentSceneIndex = Array.FindIndex (Levels,level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
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
          Debug.Log("Setting level:" + level + "Status:" + levelStatus );
    }
}
