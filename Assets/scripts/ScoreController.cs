﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI ScoreText;
    public int Score = 0;
    private void Awake()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    public void ScoreIncrease(int increament)
    {

        Score += increament;
        RefreshUI();
    }

    public void RefreshUI()
    {

        ScoreText.text = "Score: " + Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
