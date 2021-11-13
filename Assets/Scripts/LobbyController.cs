using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button levelSelectButton;
    public GameObject levelSelectPanel;
    private void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        levelSelectButton.onClick.AddListener(SelectLevel);
        exitButton.onClick.AddListener(ExitGame);
    }
    private void SelectLevel()
    {
        levelSelectPanel.SetActive(true);
    }
    private void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Ended");
    }
    private void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(1);
    }
}
