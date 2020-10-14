using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{

    public GameObject gameOver;
    public Button restartButton;

    void Start()
    {
        restartButton.onClick.AddListener(ReLoadLevel);
    }

    public void OnGameOver()
    {
        gameOver.SetActive(true); 
    }

    public void ReLoadLevel()
    {
        SceneManager.LoadScene(1);
    }

}
