using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }  // what's get

    public string[] Levels;
  
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;

            foreach (string level in Levels)
            {
                SetLevelStatus(level, E_LevelStatus.Locked);
            }

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if(GetLevelStatus(Levels[0]) == E_LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], E_LevelStatus.Unlocked);
        }
    }

    public E_LevelStatus GetLevelStatus(string level)
    {
        E_LevelStatus levelStatus = (E_LevelStatus)PlayerPrefs.GetInt(level, 0);  // 0 means Locked
        return levelStatus;
    }

    public void SetLevelStatus(string level, E_LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting Level: " + level + "Status" + levelStatus);
    }

    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, E_LevelStatus.Completed);
        //SetLevelStatus(SceneManager.GetActiveScene().name, E_LevelStatus.Completed);

        int currentSceneIndex = System.Array.FindIndex(Levels, Levels => Levels == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], E_LevelStatus.Unlocked);
        }
    }
}
