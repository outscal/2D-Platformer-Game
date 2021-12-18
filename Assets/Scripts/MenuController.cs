using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject LevelUI;

    public void GameStart()
    {
        LevelUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Start");
    }
    
    public void Info()
    {
        SceneManager.LoadScene("Info");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
