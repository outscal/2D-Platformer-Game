using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonExit;
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        buttonExit.onClick.AddListener(Lobby);
    }
    public void playerDie()
    {
        SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
        gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    private void Lobby()
    {
        SceneManager.LoadScene(0);
    }

}
