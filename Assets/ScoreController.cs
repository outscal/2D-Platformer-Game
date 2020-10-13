using System;
using System.Collections; 
using UnityEngine;
using TMPro; 

public class ScoreController : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    int score; 
    // Start is called before the first frame update
    void Start()
    {
        score = 0; 
    }

    public void IncrementScore(int increment)
    {
        score += increment;
        RefreshUI(); 

    }

   
    void RefreshUI()
    {

        scoreText.text = "SCORE:" + score.ToString(); 

    }


}
