using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI ScoreText;

    [SerializeField] public GameObject gameOverWindow;

    private PlayerController playerController;
    public void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        if (playerController != null )
        {
            Debug.Log("Player not found");
        }
        UpdateScoreText();
    }

    private void Update()
    {
        if (playerController != null && !playerController.isAlive)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverWindow.SetActive(true);
    }

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void UpdateScoreText()
    {
        ScoreText.text = "Score: " + score.ToString();
    }



    //Button scripts
    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);
    }    

    public void ButtonRestartLevel()
    {
        ReloadScene(); 
    }

    public void ButtonExit()
    {
        SceneManager.LoadScene(0);
    }
}
