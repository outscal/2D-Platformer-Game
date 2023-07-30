using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby_Controller : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;


    private void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        playButton.onClick.AddListener(QuitGame);
    }

    void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
