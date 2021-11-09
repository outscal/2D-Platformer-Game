using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour

{
    private static levelManager instance;
    public static levelManager Instance { get { return instance; } }
    public string[] Levels;

    private void Awake()
    {
        
        if (instance==null)
        {
            //PlayerPrefs.DeleteAll();
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }
    private void Start()
    {
       
        if(GetLevelStatus(Levels[0])== LevelStatus.locked)
        {
            setLevelStatus(Levels[0], LevelStatus.unlocked);
        }
    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus=(LevelStatus)PlayerPrefs.GetInt(level,0);
        return levelStatus;
    }
    public void setLevelStatus(string level,LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
}
