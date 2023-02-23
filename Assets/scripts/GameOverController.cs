using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonQuit;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        buttonQuit.onClick.AddListener(LoadLobby);
    }
    public void Playerdied ()
    {
        gameObject.SetActive(true);
    }
    private void ReloadLevel()
    {
        Debug.Log("reloading scene 0");
        //SceneManager.LoadScene(1);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
    private void LoadLobby()
    {
        SceneManager.LoadScene(0);
    }
}
