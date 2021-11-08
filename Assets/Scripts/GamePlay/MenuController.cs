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
    public Button SettingsBtn; 

    private void Awake()
    {
        RestartBtn.onClick.AddListener(onRestartBtnClick);
        LobbyBtn.onClick.AddListener(onLobbyBtnClick);
        CloseBtn.onClick.AddListener(onCloseBtnClick);
        PauseBtn.onClick.AddListener(onPauseBtnClick);
        SettingsBtn.onClick.AddListener(onSettingsBtnClick); 
    }

    public void onPauseBtnClick()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
        menuUI.SetActive(true);
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

    public void onSettingsBtnClick()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
        menuUI.SetActive(false);
        settingsUI.SetActive(true); 
    }

    public void onCloseBtnClick()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
        menuUI.SetActive(false);
    }
}
