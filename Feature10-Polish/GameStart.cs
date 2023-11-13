using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Button button;
    public int newScene;
    public string LevelName;
    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Debug.Log("Button Clicked");
        LevelStatus levelstatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelstatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Cant play this level: ");
                break;

            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(Sounds.ButtonClick);
               
                break;
            
            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                
                break;
        }

        SceneManager.LoadScene(newScene);
    }
}
