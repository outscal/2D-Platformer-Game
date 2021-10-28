using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuController : MonoBehaviour
{
    LevelLoader levelLoader; 

    public GameObject LevelMenu;
    public GameObject MainMenu; 

    public void GameStart()
    {
        LevelMenu.SetActive(true);
        MainMenu.SetActive(false); 
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Lobby()
    {
        SceneManager.LoadScene("Lobby"); 
    }

    public void CloseBtn()
    {
        gameObject.SetActive(false); 
    }

    public void NextLevelBtn()
    {
        LevelManager.Instance.MarkLevelComplete();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
