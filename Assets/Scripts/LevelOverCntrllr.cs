using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverCntrllr : MonoBehaviour
{
    public Button buttonRestart;
    public Button mainMenu;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        mainMenu.onClick.AddListener(RestartLevel);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
      //  SceneManager.LoadScene(1);
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
