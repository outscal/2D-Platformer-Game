using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class LevelCompleteController : MonoBehaviour
{
    public Button RestartBtn;
    public Button NextLevelBtn;
    public Button LobbyBtn;
    public Button CloseBtn;

    private void Awake()
    {
        RestartBtn.onClick.AddListener(onRestartBtnClick);
        NextLevelBtn.onClick.AddListener(onNextLevelBtnClick);
        LobbyBtn.onClick.AddListener(onLobbyBtnClick);
        CloseBtn.onClick.AddListener(onCloseBtnClick); 
    }

    public void LevelCompleted()
    {
        gameObject.SetActive(true);
    }

    public void onRestartBtnClick()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onLobbyBtnClick()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
        SceneManager.LoadScene("Lobby");
    }

    public void onCloseBtnClick()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
        gameObject.SetActive(false);
    }

    public void onNextLevelBtnClick()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
        LevelManager.Instance.MarkLevelComplete();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnDestroy()
    {
        RestartBtn.onClick.RemoveAllListeners();
        NextLevelBtn.onClick.RemoveAllListeners();
        LobbyBtn.onClick.RemoveAllListeners();
        CloseBtn.onClick.RemoveAllListeners(); 
    }
}
