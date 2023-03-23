using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static LevelManager Instance
    {
        get { return instance; }
    }

    public string Level1;
    string levelKeyname = "Level";
   public string[] levelsNames;
    void CreateInstance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Awake()
    {
        CreateInstance();

        PlayerPrefs.DeleteAll();
        if (GetLeveLStatus(Level1) == LevelStatus.Locked)
        {
            SetLeveLStatus(Level1, LevelStatus.Unclocked);
        }


        Debug.Log("Awake called from Level manager");
    }



    public LevelStatus GetLeveLStatus(string levelKeyname)
    {

        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(levelKeyname, 0);
        return levelStatus;

    }


    public void SetLeveLStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level,(int) levelStatus);
        print("Level_Name==" + level + "Level Status ==" + levelStatus);
       
    }

    public void MarklevelComplete()
    {
        // Mark elvel complete .........
        Scene CurrentScene = SceneManager.GetActiveScene();
        SetLeveLStatus(CurrentScene.name, LevelStatus.Complete);



        int currentindex = Array.FindIndex(levelsNames, level => (level == CurrentScene.name));

        // How this fucntion array.Fimninex works ?
        int nextSceneIndex = currentindex + 1;
        if (nextSceneIndex < levelsNames.Length)
        {
            SetLeveLStatus(levelsNames[nextSceneIndex], LevelStatus.Unclocked);
        }

    }

}
