using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI ScoreText;
    private int score = 0;

     private void Awake()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
    }

    public void ScoreIncrease (int increment)
    {
         score += increment;
         RefreshUI();
    }

    private void RefreshUI()
    {
        ScoreText.text = "Score: " +score;
    }
}
