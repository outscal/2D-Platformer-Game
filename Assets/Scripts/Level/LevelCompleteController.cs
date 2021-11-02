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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onLobbyBtnClick()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void onCloseBtnClick()
    {
        gameObject.SetActive(false);
    }

    public void onNextLevelBtnClick()
    {
        LevelManager.Instance.MarkLevelComplete();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
