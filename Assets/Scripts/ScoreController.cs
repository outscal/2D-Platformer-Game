using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public int score;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        RefreshUI();
    }

    public void AddScore(int increment)
    {
        score += increment;
        RefreshUI();
    }

    public void RefreshUI()
    {
        scoreText.text = "Score: " + score;
        

    }
}
