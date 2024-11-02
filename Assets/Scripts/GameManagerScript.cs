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

    public void Start()
    {
        UpdateScoreText();
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
}
