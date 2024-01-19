using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void OnRestart() { 
        SceneManager.LoadScene(currentScene);
    }

    public void NextLevel()
    {
        try
        {
            SceneManager.LoadScene(currentScene + 1);
        }
        catch(IndexOutOfRangeException e) { 
            Debug.Log("there is no next level.");
            Debug.Log(e);
        }
        finally { }
    }

    public void OnQuit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
