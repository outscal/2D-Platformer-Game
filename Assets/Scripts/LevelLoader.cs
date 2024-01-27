using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    string currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void OnRestart() { 
        SceneManager.LoadScene(currentScene);
    }

    public static void LevelSelector(string level)
    {

        LevelStatus levelStatus = LevelManager.Instance.getLevelStatus(level);
        switch (levelStatus)
        {
            case LevelStatus.Completed:
                
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(level);
                break;
            case LevelStatus.Locked:
                Debug.Log("This is locked.");
                break;
            default:
                Debug.Log("Something went worng.");
                break;
        }
       
    }

    public void OnQuit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
