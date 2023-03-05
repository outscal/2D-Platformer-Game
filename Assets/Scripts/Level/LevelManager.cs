using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public string Level1;
    public string[] Levels;
    public static LevelManager Instance
    {
        get { return instance; }
    }
    // Start is called before the first frame update
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
            setLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MarkedLevelComplate()
    {
        Scene scene = SceneManager.GetActiveScene();
        LevelManager.Instance.setLevelStatus(scene.name, LevelStatus.Completed);
        int nextSceneIndex = scene.buildIndex + 1;
        Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        setLevelStatus(nextScene.name, LevelStatus.Unlocked);
        int currentSceneIndex = Array.FindIndex(Levels, Level => Level == currentScene.name);
        //int nextSceneIndex = currentSceneIndex + 1;
    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }
    public void setLevelStatus(string level, LevelStatus status)
    {
        PlayerPrefs.SetInt(level, (int)status);
        Debug.Log("Setting level: "+level+" Status: "+ status);
    }
}
