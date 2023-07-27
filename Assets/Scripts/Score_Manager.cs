using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score_Manager : MonoBehaviour
{

    TMP_Text scoreText;
    int score = 0;
    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
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

    private void RefreshUI()
    {
        scoreText.text = "Score: " + score; 
    }

}
