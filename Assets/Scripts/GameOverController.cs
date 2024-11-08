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
        buttonRestart.onClick.AddListener(ReloadScene);
        buttonQuit.onClick.AddListener(OnApplicationQuit);
        


    }
    public void PlayerDied()
    {
        SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
        gameObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reload the current scene
    }

    private void OnApplicationQuit()
    {
        Application.Quit();
    }

   
}
