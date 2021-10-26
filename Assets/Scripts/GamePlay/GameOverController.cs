using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameOverController : MonoBehaviour
{
    public Button restartBtn;

    private void Awake()
    {
        restartBtn.onClick.AddListener(ReloadLevel);     
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver"); 
    }

    private void ReloadLevel()
    { 
        SceneManager.LoadScene("Level1");
    }

}
