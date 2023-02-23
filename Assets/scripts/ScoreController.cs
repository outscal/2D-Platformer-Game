using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour

{
    private static TextMeshProUGUI scoreText;
    private static int score = 0;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();


    }
    private void Start()
    {
        RefreshUI();
    }
    public void IncreaseScore(int increament)
    {
        score += increament;
        RefreshUI();
    }
    private static void RefreshUI()
    {
        scoreText.text = "Score: " + score;
    }

}