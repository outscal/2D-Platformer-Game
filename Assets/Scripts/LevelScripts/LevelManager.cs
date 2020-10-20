using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
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
        
        /*if (GetLevelStatus("1") == LevelStatus.Locked)
        {
            SetLevelStatus("1", LevelStatus.Unlocked);
        }*/
    }

    public void markCurrentlevelComplete()
    {
        Scene CurrScene = SceneManager.GetActiveScene();
        LevelManager.Instance.SetLevelStatus(CurrScene.name, LevelStatus.Completed);

        int nextSceneIndex = CurrScene.buildIndex + 1;
        Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        LevelManager.Instance.SetLevelStatus(nextScene.name, LevelStatus.Unlocked);
        SceneManager.LoadScene(nextSceneIndex);



    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus =(LevelStatus)PlayerPrefs.GetInt(level,0);
        return levelStatus;
    }

    public void SetLevelStatus(string level,LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level,(int)levelStatus);
        Debug.Log("Setting level : " + level + "Status : " + levelStatus);
    }

    
}
