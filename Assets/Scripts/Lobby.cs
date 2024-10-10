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
    public Button Level1;
    public Button Level2;
    public GameObject LevelSelector;
    public GameObject LobbyMenu;

    private void Start()
    {
        StartButton.onClick.AddListener(LevelSelect);
        QuitButton.onClick.AddListener(QuitGame);
        Level1.onClick.AddListener(PlayLevel1);
        Level2.onClick.AddListener(PlayLevel2);
        LevelSelector.SetActive(false);
        backButton.onClick.AddListener(backSelect);
       
    
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelect()
    {
        LobbyMenu.SetActive(false);
        LevelSelector.SetActive(true);
        backButton.gameObject.SetActive(true);
        Level1.onClick.AddListener(PlayLevel1);
        Level2.onClick.AddListener(PlayLevel2);
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void backSelect()
    {
        LobbyMenu.SetActive(true);
        LevelSelector.SetActive(false);
        backButton.gameObject.SetActive(false);
    }
}
