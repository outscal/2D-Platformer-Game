using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoretext;
    private int score = 0 ;

    private void Awake()
    {
        scoretext = GetComponent<TextMeshProUGUI>();
    }

    public void increaseScore(int increase)
    {
        score += increase;
        refreshUpi();
    }

    private void Start()
    {
        refreshUpi();
    }
    private void refreshUpi()
    {
        scoretext.text = "Score : " + score; 
    }
}
