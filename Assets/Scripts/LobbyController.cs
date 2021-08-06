using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button btnPlay;
    public Button btnQuit;
    public GameObject LevelSelectionPopUp;

    private void Awake()
    {
        btnPlay.onClick.AddListener(StartPlay);
        btnQuit.onClick.AddListener(QuitGame);
    }

    public void StartPlay()
    {
        print("play Button Clicked");
        // SceneManager.LoadScene(1);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelectionPopUp.SetActive(true);
    }

    public void QuitGame()
    {
        print("Quit Button Clicked");
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }

}
