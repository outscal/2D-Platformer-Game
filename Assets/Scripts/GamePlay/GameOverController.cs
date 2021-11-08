using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    public Button RestartBtn;
    public Button LobbyBtn;
    public Button QuitBtn; 

    private void Awake()
    {
        RestartBtn.onClick.AddListener(onRestartBtnClick);      
        LobbyBtn.onClick.AddListener(onLobbyBtnClick);
        QuitBtn.onClick.AddListener(onQuitBtnClick);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true); 
    }

    public void onRestartBtnClick()
    {
        Time.timeScale = 1f;
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onLobbyBtnClick()
    {
        SceneManager.LoadScene("Lobby");
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
    }

    public void onQuitBtnClick()
    {
        Application.Quit();
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
    }

}
