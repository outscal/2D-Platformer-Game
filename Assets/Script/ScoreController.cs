using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text heartText;
    public int score, heart = 3;

    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    public void IncreaseScore(int val)
    {
        score += val;
        RefreshUI();
    }

    public void DecreaseHeart()
    {
        heart--;
        RefreshUI();
    }

    public bool HeartOver()
    {
        if (heart <= 0)
        {
            return true;
        }
        return false;
    }

    void RefreshUI()
    {
        scoreText.text = "Score : " + score;
        heartText.text = "Heart : " + heart;
    }
}
