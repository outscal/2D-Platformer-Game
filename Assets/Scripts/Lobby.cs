using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{

    public Button StartButton;
    public Button QuitButton;

    private void Start()
    {
        StartButton.onClick.AddListener(PlayGame);
        QuitButton.onClick.AddListener(QuitGame);
    
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
