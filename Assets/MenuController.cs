using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject settingsUI;

    public Button RestartBtn;
    public Button LobbyBtn;
    public Button CloseBtn;
    public Button PauseBtn; 

    private void Awake()
    {
        RestartBtn.onClick.AddListener(onRestartBtnClick);
        LobbyBtn.onClick.AddListener(onLobbyBtnClick);
        CloseBtn.onClick.AddListener(onCloseBtnClick);
        PauseBtn.onClick.AddListener(onPauseBtnClick); 
    }

    public void onPauseBtnClick()
    {
        menuUI.SetActive(true);
    }

    public void onRestartBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onLobbyBtnClick()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void onSettingsBtnClick()
    {
        menuUI.SetActive(true);
    }

    public void onCloseBtnClick()
    {
        menuUI.SetActive(false);
    }
}
