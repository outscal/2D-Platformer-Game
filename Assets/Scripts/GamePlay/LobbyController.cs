using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{

    [SerializeField] private GameObject LevelMenu;
    [SerializeField] private GameObject MainMenu; 

    public Button StartBtn;
    public Button ExitBtn;

    private void Awake()
    {
        StartBtn.onClick.AddListener(onStartBtnClick);
        ExitBtn.onClick.AddListener(onExitBtnClick); 
    }

    public void onStartBtnClick()
    {
        LevelMenu.SetActive(true);
        MainMenu.SetActive(false); 
    }

    public void onExitBtnClick()
    {
        Application.Quit();
    }

}
