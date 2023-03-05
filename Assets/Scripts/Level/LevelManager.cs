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
        if(GetLevelStatus("Level1") == LevelStatus.Locked)
        {
            setLevelStatus(Level1, LevelStatus.Unlocked);
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
