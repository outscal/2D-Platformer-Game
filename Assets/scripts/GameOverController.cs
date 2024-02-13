using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public GameOverScreen gameOverScreen;
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
    }
    // Start is called before the first frame update

    public void GameOver()
    {
        gameOverScreen.Setup();
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
private void ReloadLevel()
    {
        Debug.Log("reloading scenen");
        SceneManager.LoadSceneAsync(1);
    }
}
