using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    Button buttonstartGame;
    Button buttonQuitGame;
    public string LevelName;
    private void Awake()
    {
        buttonstartGame = GetComponent<Button>();
        buttonstartGame.onClick.AddListener(OnClickStartGameButton);
    }

    private void OnClickStartGameButton()
    {
        E_LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch(levelStatus)
        {
            case E_LevelStatus.Locked:
                Debug.Log("Can't play level till you unlock it");
                break;

            case E_LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;

            case E_LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                break;
        }
    }

    public void LoadLevelIfUnlocked() // Button will use this function
    {
        if(LevelManager.Instance.GetLevelStatus(LevelName) == E_LevelStatus.Completed)
        {
            SceneManager.LoadScene(LevelName);
        }
    }
}
