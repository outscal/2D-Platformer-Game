using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverController : MonoBehaviour
{

    public Button buttonRestart;
    public Button quitButton;
    public void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        quitButton.onClick.AddListener(QuitGame);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
        ReloadLevel();
    }
    private void ReloadLevel()
    {
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    private void QuitGame()
    {
        SceneManager.LoadScene("Lobby");
    }
}
