using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshUI();
    }
    private void RefreshUI()
    {
        scoreText.text = "score:" + score;
    }
}
