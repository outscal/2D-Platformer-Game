using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button RestartButton;
    public Button QuitButton;

    private void Awake()
    {
        RestartButton.onClick.AddListener(ReloadScene);
        QuitButton.onClick.AddListener(LoadLobbyScene);
    }
   public void Playerdied()
   {
       gameObject.SetActive(true);
       Debug.Log("Player died");
   }

   public void ReloadScene()
    {
        
        SceneManager.LoadScene(1);
    }

    public void LoadLobbyScene()
    {
        SceneManager.LoadScene(0);
        gameObject.SetActive(false);
    }

    
}
