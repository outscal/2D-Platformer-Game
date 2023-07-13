using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonMainMenu;
    
    public void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        buttonMainMenu.onClick.AddListener(MainMenu);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    public void ReloadLevel()
    {
        Debug.Log("Reloading Scene 1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);      //Can also do with SceneManager.LoadScene(0);
    }
    public void MainMenu()
    {
        Debug.Log("Loading scene 0");
        SceneManager.LoadScene(0);  
    }
}
