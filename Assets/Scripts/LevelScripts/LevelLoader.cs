using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;

    [SerializeField] private string levelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (SceneManager.GetActiveScene().name == "LevelComplete")
        {
            button.onClick.AddListener(LoadNextLevel);
        }
        else
        {
            button.onClick.AddListener(onClick);
        }
        
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = LevelManager.Instance.nextSceneIndex - 1;
        if (currentSceneIndex < LevelManager.Instance.Levels.Length)
        {
            levelName = LevelManager.Instance.Levels[LevelManager.Instance.nextSceneIndex];
            SceneManager.LoadScene(levelName);
        }
        //else
        //{
        //    SceneManager.LoadScene("GameComplete");
        //}
    }

    private void onClick()
    {
        LevelStatus status = LevelManager.Instance.GetLevelStatus(levelName);
        switch (status)
        {
            case LevelStatus.Locked:
                Debug.Log("Level Locked. Unlock it to play");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(levelName);
                break;
        }
    }
}
