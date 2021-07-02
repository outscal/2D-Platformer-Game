using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    
    private TextMeshProUGUI scoreText;
    // public int score;
    public int score;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void start(){
        RefreshUI();
    }
    public void increaseScore(int increment)
    {
        score += increment;
        RefreshUI();
    } 

    private void RefreshUI(){
        scoreText.text = "Score: " + score;
    }
}
