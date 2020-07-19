using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject levelSelection;
    public Button playButton;
    public Button quitButton;
    public string levelName;
    private void Awake()
    {
        playButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    
    private void StartGame()
    {
        mainmenu.SetActive(false);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        levelSelection.SetActive(true);
    }

    private void QuitGame()
    {
        Application.Quit();
        //hello
    }
}
