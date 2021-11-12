using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button exitGame;
    public Button mainMenu;
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        mainMenu.onClick.AddListener(MainMenu);
        exitGame.onClick.AddListener(ExitGame);
    }
    public void PlayerDied()
    {
        SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
        gameObject.SetActive(true);
    }
    private void MainMenu()
    {
        Debug.Log("Back to Main Menu");
        SceneManager.LoadScene(0);
    }
    private void ExitGame()
    {
        Debug.Log("Game has been exited");
        Application.Quit();
    }
    public void ReloadLevel()
    {
        Debug.Log("Reloading Scene 0");
        SceneManager.LoadScene(1);
    }
}
