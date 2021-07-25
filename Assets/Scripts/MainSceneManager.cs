using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class MainSceneManager : MonoBehaviour
{
    public Button StartButton;
    public Button LevelButton;
    public Button OptionsButton;
    public Button QuitButton;

    public GameObject Panel;
    public GameObject LevelsText;
    public GameObject Menu;
    public GameObject Title;


    private void Awake()
    {
        StartButton.onClick.AddListener(StartGame);
        QuitButton.onClick.AddListener(QuitGame);
        LevelButton.onClick.AddListener(LevelPanel);
    }

    private void LevelPanel()
    {
        Panel.SetActive(true);
        LevelsText.SetActive(true);
        Menu.SetActive(false);
        Title.SetActive(false);
    }

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Clicked Quit");
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Clicked Start");
    }

}
