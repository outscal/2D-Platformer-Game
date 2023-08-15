using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonQuit;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
        buttonPlay.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    } 

    private void QuitGame()
    {
        Application.Quit();
    } 
}
