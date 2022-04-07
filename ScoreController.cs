using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private int score = 0;


    /// Awake is called when the script instance is being loaded.

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

/// Start is called on the frame when a script is enabled just before
/// any of the Update methods is called the first time.

    private void Start()
    {
        RefreshUI();
    }

    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = " Score " +  score;
    }


}
