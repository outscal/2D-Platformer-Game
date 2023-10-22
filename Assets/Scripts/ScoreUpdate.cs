using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    private int score = 0;

    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        SetUi();    
    }

    public void IncreaseScore()
    {
        score++;
        SetUi();
    }

    private void SetUi()
    {
        scoreText.text = score.ToString();
    }
}
