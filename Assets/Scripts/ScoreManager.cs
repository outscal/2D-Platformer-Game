using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        refreshUI();
    }
    public void IncreaseScore(int increment)
    {
        score += increment;
        refreshUI();
    }
    private void refreshUI()
    {
        scoreText.text = "Score:" +score.ToString();
    }

}
