using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI Score_Text;
    int Score = 0;
    private void Awake()
    {
        Score_Text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        //whenever Game Started score will automaticaly be zero(even when switch to a different scene it helps) as we have defined it zero 
        IncreasingScoreInUI();
    }
    public void Update_Score(int increase )
    {
        Score += increase;
        IncreasingScoreInUI(); 
    }

    private void IncreasingScoreInUI()
    {
        Score_Text.text = "Score: " + Score;
    }
}
