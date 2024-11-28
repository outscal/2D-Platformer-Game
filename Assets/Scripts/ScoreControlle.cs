using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreControlle : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int Score = 0;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();    
    }

    private void Start()
    {
        RefereshUI();
    }


    public void IncreaseScore(int increment)
    {
        Score += increment;
        RefereshUI();
    }

    private void RefereshUI()
    {
       scoreText.text = "Score :" + Score;
     }
}
