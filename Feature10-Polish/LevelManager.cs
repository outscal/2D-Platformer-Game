using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
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

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelstatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
        return levelstatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelstatus)
    {
        PlayerPrefs.SetInt(level, (int)levelstatus);
    }
}
