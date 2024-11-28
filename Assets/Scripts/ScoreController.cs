using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private static ScoreController instance;
    public static ScoreController Instance { get { return instance; } }

    private TextMeshProUGUI scoreText;
    private int score = 0;
    private const string ScoreKey = "PlayerScore";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
            LoadScore(); // Load score from PlayerPrefs
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate
        }

        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void Start()
    {
        RefreshUI();
    }

    public void IncreaseScore(int increment)
    {
        score += increment;
        SaveScore(); // Save score to PlayerPrefs
        RefreshUI();
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt(ScoreKey, score);
        PlayerPrefs.Save();
    }

    private void LoadScore()
    {
        score = PlayerPrefs.GetInt(ScoreKey, 0); // Default score is 0 if not set
    }

    private void RefreshUI()
    {
        scoreText.text = "Score: " + score;
    }

    public void ResetPlayerData()
    {
        PlayerPrefs.DeleteKey("PlayerScore");
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.Save();
    }


    public int GetScore()
    {
        return score;
    }

}
