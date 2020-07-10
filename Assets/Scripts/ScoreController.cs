using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int Score;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        RefreshUI();
    }
    public void IncreaseScore(int increment)
    {
        Score += increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = "Score: " + Score;
    }
}
