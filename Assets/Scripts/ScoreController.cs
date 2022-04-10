using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private int score = 0;
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
      score += increment;
      RefreshUI();
    }

    private void RefreshUI()
    {
      scoreText.text = "Score: " + score;
    }
}
