using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    public Button StartButton;
    public Button QuitButton;
    public Button backButton;
    public GameObject LevelSelector;
    public GameObject LobbyMenu;

    private void Start()
    {
        StartButton.onClick.AddListener(LevelSelect);
        QuitButton.onClick.AddListener(QuitGame);

        LevelSelector.SetActive(false);
        backButton.onClick.AddListener(backSelect);
    }

    public void QuitGame()
    {
        SoundManager.Instance.PlayExitSound();
        Application.Quit();
    }

    public void LevelSelect()
    {
        SoundManager.Instance.PlayStartSound();
        LobbyMenu.SetActive(false);
        LevelSelector.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    public void LoadLevel(string levelName)
    {
        SoundManager.Instance.PlayLevelSound();
        SceneManager.LoadScene(levelName);
    }

    public void backSelect()
    {
        SoundManager.Instance.PlayBackSound();
        LobbyMenu.SetActive(true);
        LevelSelector.SetActive(false);
        backButton.gameObject.SetActive(false);
    }
}
