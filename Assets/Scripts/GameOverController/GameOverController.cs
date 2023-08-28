using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonHome;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        buttonHome.onClick.AddListener(GoHome);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        Debug.Log(" Reloading Active Scene ");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoHome()
    {
        Debug.Log(" Going to Home Lobby Screen/Scene ");
        SceneManager.LoadScene(0);
    }
}
 