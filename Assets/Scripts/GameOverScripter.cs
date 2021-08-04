using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOverScripter : MonoBehaviour
{
    public Button buttonRestart;
    public Button quiter;

    private void Awake()
    {
         buttonRestart.onClick.AddListener(ReloadGame);
        quiter.onClick.AddListener(QuitGame);
      
    }

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
        //throw new NotImplementedException();
    }

    public void playerDied()
    {
        gameObject.SetActive(true);
    }

    private void ReloadGame()
    {
        Debug.Log("Reload");
        SceneManager.LoadScene("S2");
    }

}
