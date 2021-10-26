using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuController : MonoBehaviour
{
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

}
