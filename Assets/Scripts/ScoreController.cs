using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI Scoredisplay;

    private int score;

    private void Awake() 
    {
        Scoredisplay = GetComponent<TextMeshProUGUI>();
    }
    private void Start() 
    {
        UpdateScore();
    }
    public void ScoreIncrement(int incrementval)
    {
        score += incrementval;
        UpdateScore();
    }
    public void UpdateScore()
    {
        Scoredisplay.text = "Score: " + score;
    }
}
