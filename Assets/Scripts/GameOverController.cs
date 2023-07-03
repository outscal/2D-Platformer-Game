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
    }
    private void ReloadLevel()
    {
        //throw new NotImplementedException();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //playerHealth = playerHealth - 1;

    }
    private void QuitGame()
    {
        SceneManager.LoadScene("Lobby");

    }
}
