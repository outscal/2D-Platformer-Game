using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    private void Awake()
    {
        score = 0;
       
    }



    public void ScoreController(int scoreraise)
    {
        score += scoreraise;

        IncreaseScore();

    }
    private void IncreaseScore()
    {

        scoreText.text = "Score :" + score;
    }

}
