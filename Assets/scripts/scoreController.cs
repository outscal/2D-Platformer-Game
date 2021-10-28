using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class scoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score= 0;
    // Start is called before the first frame update
    private void Awake()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    
    public void IncrementScore( int inc)
    {
        score += inc;
        RefeshUI();
    }

    private void RefeshUI()
    {
        scoreText.text = "SCORE :" + score.ToString();
    }

   
}
