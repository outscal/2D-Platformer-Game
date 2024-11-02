using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text scoreText;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    internal void IncreaseScore(int val)
    {
        score += val;
        RefreshUI();
    }

    void RefreshUI()
    {
        scoreText.text = "Score : " + score;
    }
}
